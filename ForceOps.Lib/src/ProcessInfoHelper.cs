using Serilog;

namespace ForceOps.Lib;

class ProcessInfoHelper
{
    readonly ForceOpsContext forceOpsContext;
	readonly ILogger logger;
    public ProcessInfoHelper(ForceOpsContext forceOpsContext)
    {
		logger = ForceOpsLoggerFactory.CreateLogger<ProcessInfoHelper>();
        this.forceOpsContext = forceOpsContext;
    }

	public IEnumerable<LockCheck.ProcessInfo> FilterNullProcesses(IEnumerable<LockCheck.ProcessInfo> processInfos)
	{
		foreach (var processInfo in processInfos)
		{
			if (processInfo == null)
			{
                var isProcessElevated = forceOpsContext.elevateUtils.IsProcessElevated();
                var message = $"LockCheck API returned a null process. {GetAdminLogMessage(isProcessElevated)}";
                if (isProcessElevated) {
                    logger.Error(message);
                } else {
                    logger.Warning(message);
                }
				continue;
			}
			yield return processInfo;
		}
	}

	public static string GetAdminLogMessage(bool isProcessElevated)
	{
		if (isProcessElevated)
		{
			return "Process is NOT elevated";
		}
		return "Process is elevated";
	}

	public static string GetProcessLogString(IEnumerable<LockCheck.ProcessInfo> processes)
	{
		return $"[{string.Join(", ", processes.Select(process => $"{process?.ProcessId} - {process?.ExecutableName}"))}]";
	}
}