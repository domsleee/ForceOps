namespace ForceOps.Lib;

public class ForceOpsContext
{
	public int maxAttempts = 5;
	public IProcessKiller processKiller;
	public IElevateUtils elevateUtils;
	public IRelaunchAsElevated relaunchAsElevated;
	public ILoggerFactory loggerFactory;

	public ForceOpsContext(
		IProcessKiller? processKiller = null,
		IElevateUtils? elevateUtils = null,
		IRelaunchAsElevated? relaunchAsElevated = null,
		ILoggerFactory? loggerFactory = null
	)
	{
		this.processKiller = processKiller ?? new ProcessKiller();
		this.elevateUtils = elevateUtils ?? new ElevateUtils();
		this.relaunchAsElevated = relaunchAsElevated ?? new RelaunchAsElevated();
		this.loggerFactory = loggerFactory ?? new LoggerFactory();
	}
}
