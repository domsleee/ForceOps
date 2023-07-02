namespace ForceOps.Lib;

public class ForceOpsContext
{
	public int maxRetries = 3;
	public IProcessKiller processKiller;
	public IElevateUtils elevateUtils;
	public IRelaunchAsElevated relaunchAsElevated;

	public ForceOpsContext(IProcessKiller? processKiller = null, IElevateUtils? elevateUtils = null, IRelaunchAsElevated? relaunchAsElevated = null)
	{
		this.processKiller = processKiller ?? new ProcessKiller();
		this.elevateUtils = elevateUtils ?? new ElevateUtils();
		this.relaunchAsElevated = relaunchAsElevated ?? new RelaunchAsElevated();
	}
}
