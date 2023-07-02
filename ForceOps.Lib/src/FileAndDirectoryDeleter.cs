using System.Runtime.Versioning;
using Serilog;
using static ForceOps.Lib.DirectoryUtils;

namespace ForceOps.Lib;

[SupportedOSPlatform("windows")]
public class FileAndDirectoryDeleter
{
	readonly ILogger logger;
	readonly ForceOpsContext forceOpsContext;

	public FileAndDirectoryDeleter(ForceOpsContext forceOpsContext, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext;
		this.logger = logger ?? ForceOpsLoggerFactory.CreateLogger<FileAndDirectoryDeleter>();
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
		logger.Debug($"{fileOrDirectory} deleted.");
		return;
	}

	internal void DeleteFile(FileInfo file)
	{
		for (var retries = forceOpsContext.maxRetries; retries >= 0; retries--)
		{
			try
			{
				file.IsReadOnly = false;
				file.Delete();
				break;
			}
			catch when (!file.Exists) { }
			catch (Exception ex) when ((ex is IOException || ex is System.UnauthorizedAccessException) && retries > 0)
			{
				var processes = FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { file.FullName }));
				logger.Information($"DeleteFolder found these processes: {GetProcessLogString(processes)}");
				forceOpsContext.processKiller!.KillProcesses(processes);
			}
		}
	}

	internal void DeleteDirectory(DirectoryInfo directory)
	{
		if (!IsSymLink(directory))
		{
			DeleteFilesInFolder(directory);
		}

		for (var retries = forceOpsContext.maxRetries; retries >= 0; retries--)
		{
			try
			{
				directory.Delete();
				break;
			}
			catch when (!directory.Exists) { }
			catch (Exception ex) when (ex is IOException && retries > 0)
			{
				var processes = FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { directory.FullName }, LockCheck.LockManagerFeatures.UseLowLevelApi));
				logger.Information($"DeleteFolder found these processes: {GetProcessLogString(processes)}");
				forceOpsContext.processKiller.KillProcesses(processes);
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

	IEnumerable<LockCheck.ProcessInfo> FilterNullProcesses(IEnumerable<LockCheck.ProcessInfo> processInfos)
	{
		foreach (var processInfo in processInfos)
		{
			if (processInfo == null)
			{
				var isProcessElevated = forceOpsContext.elevateUtils.IsProcessElevated();
				var message = $"LockCheck API returned a null process. {GetAdminLogMessage(isProcessElevated)}";
				if (isProcessElevated)
				{
					logger.Error(message);
				}
				else
				{
					logger.Warning(message);
				}
				continue;
			}
			yield return processInfo;
		}
	}

	string GetAdminLogMessage(bool isProcessElevated)
	{
		if (!isProcessElevated)
		{
			return "Process is NOT elevated";
		}
		return "Process is elevated";
	}

	string GetProcessLogString(IEnumerable<LockCheck.ProcessInfo> processes)
	{
		return $"[{string.Join(", ", processes.Select(process => $"{process?.ProcessId} - {process?.ExecutableName}"))}]";
	}
}