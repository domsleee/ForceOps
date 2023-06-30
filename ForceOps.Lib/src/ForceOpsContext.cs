using ForceOpsLib;

namespace ForceOps;
public class ForceOpsContext
{
	public int maxRetries = 3;
	public IProcessKiller processKiller;
	public IElevateUtils elevateUtils;

	public ForceOpsContext(IProcessKiller? processKiller = null, IElevateUtils? elevateUtils = null)
	{
		this.processKiller = processKiller ?? new ProcessKiller();
		this.elevateUtils = elevateUtils ?? new ElevateUtils();
	}
}
