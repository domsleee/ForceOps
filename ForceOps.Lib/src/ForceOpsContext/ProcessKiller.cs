using System.ComponentModel;
using System.Diagnostics;
using LockCheck;
using Serilog;

namespace ForceOps.Lib;

internal class ProcessKiller : IProcessKiller
{
	public void KillProcesses(IEnumerable<ProcessInfo?> processes, ILogger logger)
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
			try
			{
				process.Kill();
			}
			catch (Win32Exception ex) // e.g. if the process is owned by another user
			{
				logger.Warning($"Failed to kill process {process.Id}: {ex.Message}");
			}
		}
	}
}
