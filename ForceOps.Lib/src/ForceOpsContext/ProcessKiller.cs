using System.Diagnostics;
using LockCheck;

namespace ForceOps.Lib;

internal class ProcessKiller : IProcessKiller
{
	public void KillProcesses(IEnumerable<ProcessInfo?> processes)
	{
		var runningProcesses = new List<Process>();
		foreach (var process in processes)
		{
			if (process == null) continue;
			try
			{
				runningProcesses.Add(Process.GetProcessById(process.ProcessId));
			}
			catch (ArgumentException) { } // If the process is no longer running
		}

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
