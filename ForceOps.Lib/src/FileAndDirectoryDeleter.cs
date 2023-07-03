using System.Runtime.Versioning;
using Serilog;
using static ForceOps.Lib.DirectoryUtils;
using static LockCheck.LockManager;

namespace ForceOps.Lib;

[SupportedOSPlatform("windows")]
public class FileAndDirectoryDeleter
{
	readonly ILogger logger;
	readonly ForceOpsContext forceOpsContext;

	public FileAndDirectoryDeleter(ForceOpsContext forceOpsContext, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext;
		this.logger = logger ?? forceOpsContext.loggerFactory.CreateLogger<FileAndDirectoryDeleter>();
	}

	/// <summary>
	/// Delete a file or a folder, not following symlinks.
	/// If the delete fails, it will attempt to find processes using the file or directory
	/// </summary>
	/// <param name="fileOrDirectory">File or directory to delete.</param>
	public void DeleteFileOrDirectory(string fileOrDirectory)
	{
		fileOrDirectory = CombineWithCWDAndGetAbsolutePath(fileOrDirectory);
		if (File.Exists(fileOrDirectory))
		{
			DeleteFile(new FileInfo(fileOrDirectory));
			return;
		}
		if (Directory.Exists(fileOrDirectory))
		{
			DeleteDirectory(new DirectoryInfo(fileOrDirectory));
			return;
		}
		// if the file/folder doesn't exist, it has already been deleted
		logger.Debug($"{fileOrDirectory} already deleted.");
		return;
	}

	internal void DeleteFile(FileInfo file)
	{
		for (var attempt = 1; attempt <= forceOpsContext.maxAttempts; attempt++)
		{
			try
			{
				file.IsReadOnly = false;
				file.Delete();
				break;
			}
			catch when (!file.Exists) { }
			catch (Exception ex) when (ex is IOException || ex is System.UnauthorizedAccessException)
			{
				var getProcessesLockingFileFunc = () => GetLockingProcessInfos(new[] { file.FullName });
				var shouldThrow = KillProcessesAndLogInfo("DeleteFile", attempt, file.FullName, getProcessesLockingFileFunc);
				if (shouldThrow) throw;
			}
		}
	}

	bool KillProcessesAndLogInfo(string actionName, int attemptNumber, string fileOrDirectoryPath, Func<IEnumerable<LockCheck.ProcessInfo>> getProcessesLockingFileFunc)
	{
		var isProcessElevated = forceOpsContext.elevateUtils.IsProcessElevated();
		var processElevatedMessage = isProcessElevated
			? "ForceOps process is elevated"
			: "ForceOps process is not elevated";
		var messagePrefix = $"{actionName} failed attempt {attemptNumber}/{forceOpsContext.maxAttempts} for [{fileOrDirectoryPath}]. {processElevatedMessage}.";

		if (attemptNumber == forceOpsContext.maxAttempts) {
			logger.Information($"{messagePrefix} No attempts remain, so the exception will be thrown.");
			return true;
		}

		var processes = getProcessesLockingFileFunc().ToList();
		var processPlural = processes.Count == 1 ? "process" : "processes";
		var processLogString = string.Join(", ", processes.Select(process => ProcessInfoToString(process)));
		logger.Information($"{messagePrefix} Found {processes.Count} {processPlural} to try to kill: [{processLogString}]");
		forceOpsContext.processKiller.KillProcesses(processes);
		return false;
	}

	static string ProcessInfoToString(LockCheck.ProcessInfo? process) {
		if (process == null) {
			return "<null>";
		}
		return $"{process?.ProcessId} - {process?.ExecutableName}";
	}

	internal void DeleteDirectory(DirectoryInfo directory)
	{
		if (!IsSymLink(directory))
		{
			DeleteFilesInFolder(directory);
		}

		for (var attempt = 1; attempt <= forceOpsContext.maxAttempts; attempt++)
		{
			try
			{
				directory.Delete();
				break;
			}
			catch when (!directory.Exists) { }
			catch (Exception ex) when (ex is IOException)
			{
				var getProcessesLockingFileFunc = () => GetLockingProcessInfos(new[] { directory.FullName }, LockCheck.LockManagerFeatures.UseLowLevelApi);
				var shouldThrow = KillProcessesAndLogInfo("DeleteDirectory", attempt, directory.FullName, getProcessesLockingFileFunc);
				if (shouldThrow) throw;
			}
		}
	}

	void DeleteFilesInFolder(DirectoryInfo directory)
	{
		foreach (var file in directory.GetFiles())
		{
			DeleteFile(file);
		}
		foreach (var subDirectory in directory.GetDirectories())
		{
			DeleteDirectory(subDirectory);
		}
	}
}