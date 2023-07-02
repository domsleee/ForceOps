using System.Runtime.Versioning;
using Serilog;
using static ForceOps.Lib.DirectoryUtils;

namespace ForceOps.Lib;

[SupportedOSPlatform("windows")]
public class FileAndDirectoryDeleter
{
	readonly ILogger logger;
	readonly ForceOpsContext forceOpsContext;
    readonly ProcessInfoHelper processInfoHelper;

	public FileAndDirectoryDeleter(ForceOpsContext? forceOpsContext, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext ?? new ForceOpsContext();
		this.logger = logger ?? ForceOpsLoggerFactory.CreateLogger<FileAndDirectoryDeleter>();
		processInfoHelper = new ProcessInfoHelper(forceOpsContext!);
	}

	/// Delete a file or a folder, not following symlinks.
	/// If the delete fails, it will attempt to find processes using the file or directory
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
		var retries = forceOpsContext.maxRetries;
		do
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
				var processes = processInfoHelper.FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { file.FullName }));
				logger.Information($"DeleteFolder found these processes: {ProcessInfoHelper.GetProcessLogString(processes)}");
				forceOpsContext.processKiller!.KillProcesses(processes);
			}
		} while (retries-- > 0);
	}

	internal void DeleteDirectory(DirectoryInfo directory)
	{
		if (!IsSymLink(directory))
		{
			DeleteFilesInFolder(directory);
		}

		var retries = forceOpsContext.maxRetries;
		do
		{
			try
			{
				directory.Delete();
				break;
			}
			catch when (!directory.Exists) { }
			catch (Exception ex) when (ex is IOException && retries > 0)
			{
				var processes = processInfoHelper.FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { directory.FullName }, LockCheck.LockManagerFeatures.UseLowLevelApi));
				logger.Information($"DeleteFolder found these processes: {ProcessInfoHelper.GetProcessLogString(processes)}");
				forceOpsContext.processKiller.KillProcesses(processes);
			}
		} while (retries-- > 0);

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