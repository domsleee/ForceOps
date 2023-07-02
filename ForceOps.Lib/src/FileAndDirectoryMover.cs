using Serilog;

namespace ForceOps.Lib;

public class FileAndDirectoryMover
{
    readonly ILogger logger;
	readonly ForceOpsContext forceOpsContext;
    readonly ProcessInfoHelper processInfoHelper;

    public FileAndDirectoryMover(ForceOpsContext? forceOpsContext = null, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext ?? new ForceOpsContext();
		this.logger = logger ?? ForceOpsLoggerFactory.CreateLogger<FileAndDirectoryDeleter>();
        processInfoHelper = new ProcessInfoHelper(forceOpsContext!);
	}

    public void MoveFileOrDirectory(string sourceFileName, string destFileName) {
		if (File.Exists(sourceFileName))
		{
			MoveFile(new FileInfo(sourceFileName), destFileName);
			return;
		}
		if (Directory.Exists(sourceFileName))
		{
			MoveDirectory(new DirectoryInfo(sourceFileName), destFileName);
			return;
		}
        throw new IOException($"File or directory does not exist. {sourceFileName}");
     }

	void MoveFile(FileInfo sourceFileInfo, string destFileName)
	{
		for (var retries = forceOpsContext.maxRetries; retries >= 0; retries--)
		{
			try
			{
				sourceFileInfo.MoveTo(destFileName);
			}
			catch (Exception ex) when ((ex is IOException || ex is System.UnauthorizedAccessException) && retries > 0)
			{
				var processes = processInfoHelper.FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { sourceFileInfo.FullName }));
				logger.Information($"MoveFile found these processes: {ProcessInfoHelper.GetProcessLogString(processes)}");
				forceOpsContext.processKiller!.KillProcesses(processes);
			}
		}
	}

	void MoveDirectory(DirectoryInfo directoryInfo, string destFileName)
	{
		for (var retries = forceOpsContext.maxRetries; retries >= 0; retries--)

			try
			{
				directoryInfo.MoveTo(destFileName);
			}
			catch (Exception ex) when ((ex is IOException || ex is System.UnauthorizedAccessException) && retries > 0)
			{
				var processes = processInfoHelper.FilterNullProcesses(LockCheck.LockManager.GetLockingProcessInfos(new[] { directoryInfo.FullName }));
				logger.Information($"MoveDirectory found these processes: {ProcessInfoHelper.GetProcessLogString(processes)}");
				forceOpsContext.processKiller!.KillProcesses(processes);
			}
	}
}