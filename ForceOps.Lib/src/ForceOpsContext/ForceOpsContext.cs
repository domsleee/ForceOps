namespace ForceOps.Lib;

public class ForceOpsContext
{
	/// <summary>
	/// The number of retries when performing an operation.
	/// For example, five retries equals six total attempts.
	/// </summary>
	public int maxRetries = 5;

	/// <summary>
	/// The time to wait between before retrying the operation.
	/// </summary>
	public TimeSpan retryDelay = TimeSpan.FromMilliseconds(500);

	public IProcessKiller processKiller;
	public IElevateUtils elevateUtils;
	public IRelaunchAsElevated relaunchAsElevated;
	public ILoggerFactory loggerFactory;
	public IEnvironmentExit environmentExit;

	public ForceOpsContext(
		IProcessKiller? processKiller = null,
		IElevateUtils? elevateUtils = null,
		IRelaunchAsElevated? relaunchAsElevated = null,
		ILoggerFactory? loggerFactory = null,
		IEnvironmentExit? environmentExit = null
	)
	{
		this.processKiller = processKiller ?? new ProcessKiller();
		this.elevateUtils = elevateUtils ?? new ElevateUtils();
		this.relaunchAsElevated = relaunchAsElevated ?? new RelaunchAsElevated();
		this.loggerFactory = loggerFactory ?? new LoggerFactory();
		this.environmentExit = environmentExit ?? new EnvironmentExit();
	}
}
