using System.Diagnostics;
using LockCheck;

namespace ForceOps.Lib;

internal class ProcessKiller : IProcessKiller
{
	public void KillProcesses(IEnumerable<ProcessInfo?> processes)
	{
		var runningProcesses = new List<Process>();
		var currentProcess = Process.GetCurrentProcess();
		foreach (var process in processes)
		{
			if (process == null) continue;
			if (currentProcess?.Id == process.ProcessId) continue;
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
