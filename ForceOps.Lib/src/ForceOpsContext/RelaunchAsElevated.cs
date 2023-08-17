using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ForceOps.Lib;

public class RelaunchAsElevated : IRelaunchAsElevated
{
	internal string verb = "runas";
	internal string? exeNameOverride = null;

	int IRelaunchAsElevated.RelaunchAsElevated(List<string> argumentList)
	{
		var exeName = exeNameOverride ?? Environment.ProcessPath;
		var startInfo = new ProcessStartInfo(exeName!)
		{
			UseShellExecute = true,
			WorkingDirectory = Environment.CurrentDirectory,
			Verb = verb,
		};

		AddRange(startInfo.ArgumentList, argumentList);

		var process = new Process() { StartInfo = startInfo };

		process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
		process.ErrorDataReceived += (sender, e) => Console.Error.WriteLine(e.Data);

		process.Start();
		process.WaitForExit();

		return process.ExitCode;
	}

	static void AddRange(Collection<string> argList, IEnumerable<string> argsToAdd)
	{
		foreach (var arg in argsToAdd)
		{
			argList.Add(arg);
		}
	}
}
