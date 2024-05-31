using System.ComponentModel;
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
	public void DeleteFileOrDirectory(string fileOrDirectory, bool force)
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

		if (!force)
		{
			throw new FileNotFoundException($"Cannot remove '{fileOrDirectory}'. No such file or directory");
		}
	}

	const int ERROR_ACCESS_DENIED = 5;
	internal void DeleteFile(FileInfo file)
	{
		for (var attempt = 1; attempt <= forceOpsContext.maxRetries + 1; attempt++)
		{
			try
			{
				MarkAsNotReadOnly(file);
				file.Delete();
				break;
			}
			catch when (!file.Exists) { }
			catch (Exception ex) when (ex is IOException || ex is System.UnauthorizedAccessException)
			{
				var getProcessesLockingFileFunc = () =>
				{
					try
					{
						return GetLockingProcessInfos(new[] { file.FullName });
					}
					catch (Win32Exception e)
					{
						if (e.NativeErrorCode == ERROR_ACCESS_DENIED)
						{
							logger.Warning($"Ignored exception: {e.Message}");
						}
						else
						{
							throw;
						}
					}

					return Enumerable.Empty<LockCheck.ProcessInfo>();
				};
				var shouldThrow = KillProcessesAndLogInfo(false, attempt, file.FullName, getProcessesLockingFileFunc);
				if (shouldThrow) throw;
			}
		}
	}

	bool KillProcessesAndLogInfo(bool isDirectory, int attemptNumber, string fileOrDirectoryPath, Func<IEnumerable<LockCheck.ProcessInfo>> getProcessesLockingFileFunc)
	{
		var isProcessElevated = forceOpsContext.elevateUtils.IsProcessElevated();
		var processElevatedMessage = isProcessElevated
			? "ForceOps process is elevated"
			: "ForceOps process is not elevated";

		if (attemptNumber > forceOpsContext.maxRetries)
		{
			logger.Information($"Exceeded retry count of {forceOpsContext.maxRetries}. Failed. {processElevatedMessage}.");
			return true;
		}

		var processes = getProcessesLockingFileFunc().ToList();
		var fileOrDirectory = isDirectory
			? "directory"
			: "file";
		var processPlural = processes.Count == 1 ? "process" : "processes";
		var processLogString = string.Join(", ", processes.Select(process => ProcessInfoToString(process)));
		var beginningRetryMessage = $"Beginning retry {attemptNumber}/{forceOpsContext.maxRetries} in {forceOpsContext.retryDelay.TotalMilliseconds}ms";
		var foundProcessesToKillMessage = $"Found {processes.Count} {processPlural} to try to kill: [{processLogString}]";

		logger.Information($"Could not delete {fileOrDirectory} \"{fileOrDirectoryPath}\". {beginningRetryMessage}. {processElevatedMessage}. {foundProcessesToKillMessage}.");
		Thread.Sleep(forceOpsContext.retryDelay);

		forceOpsContext.processKiller.KillProcesses(processes, logger);
		return false;
	}

	static string ProcessInfoToString(LockCheck.ProcessInfo? process)
	{
		if (process == null)
		{
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

		for (var attempt = 1; attempt <= forceOpsContext.maxRetries + 1; attempt++)
		{
			try
			{
				MarkAsNotReadOnly(directory);
				directory.Delete();
				break;
			}
			catch when (!directory.Exists) { }
			catch (Exception ex) when (ex is IOException)
			{
				var getProcessesLockingFileFunc = () => GetLockingProcessInfos(new[] { directory.FullName }, LockCheck.LockManagerFeatures.UseLowLevelApi);
				var shouldThrow = KillProcessesAndLogInfo(true, attempt, directory.FullName, getProcessesLockingFileFunc);
				if (shouldThrow) throw;
			}
		}
	}

	void DeleteFilesInFolder(DirectoryInfo directory)
	{
		foreach (var fileOrDirectory in directory.GetFileSystemInfos())
		{
			if (fileOrDirectory is FileInfo file)
			{
				DeleteFile(file);
			}
			else if (fileOrDirectory is DirectoryInfo subDirectory)
			{
				DeleteDirectory(subDirectory);
			}
		}
	}
}