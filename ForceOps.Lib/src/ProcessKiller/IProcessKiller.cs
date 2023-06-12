namespace ForceOps;
public interface IProcessKiller
{
	void KillProcesses(IEnumerable<LockCheck.ProcessInfo> processes);
}
