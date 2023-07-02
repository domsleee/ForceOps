using System.Diagnostics;
using LockCheck;

namespace ForceOps.Lib;

internal class ProcessKiller : IProcessKiller
{
	public void KillProcesses(IEnumerable<ProcessInfo> processes)
	{
		var runningProcesses = processes.Select(process => Process.GetProcessById(process.ProcessId)).Where(process => process != null).ToList();

		foreach (var process in runningProcesses)
		{
			process.Kill();
		}

		foreach (var process in runningProcesses)
		{
			process.WaitForExit();
		}
	}
}
