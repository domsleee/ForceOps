namespace ForceOps;
public class ForceOpsContext
{
	public int maxRetries = 3;
	public IProcessKiller processKiller;

	public ForceOpsContext(IProcessKiller? processKiller = null)
	{
		this.processKiller = processKiller ?? new ProcessKiller();
	}
}
