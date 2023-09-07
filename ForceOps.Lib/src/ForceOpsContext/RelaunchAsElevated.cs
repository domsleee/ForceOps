using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ForceOps.Lib;

public class RelaunchAsElevated : IRelaunchAsElevated
{
	internal string verb = "runas";
	internal string? exeNameOverride = null;

	int IRelaunchAsElevated.RelaunchAsElevated(List<string> argumentList, string outputFile)
	{
		var exeName = exeNameOverride ?? Environment.ProcessPath;
		var startInfo = new ProcessStartInfo("cmd.exe")
		{
			UseShellExecute = true,
			WorkingDirectory = Environment.CurrentDirectory,
			Verb = verb,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden
		};

		AddRange(startInfo.ArgumentList, new[] {"/c", exeName!});
		AddRange(startInfo.ArgumentList, argumentList);

		var process = new Process() { StartInfo = startInfo };

		process.Start();
		TeeCommand.TeeFile(process, outputFile);

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
