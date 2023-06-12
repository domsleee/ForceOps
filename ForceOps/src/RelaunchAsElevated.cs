using System.Diagnostics;

namespace ForceOps.src;
internal class RelaunchAsElevated : IRelaunchAsElevated
{
	int IRelaunchAsElevated.RelaunchAsElevated()
	{
		var exeName = Environment.ProcessPath;
		var startInfo = new ProcessStartInfo(exeName!)
		{
			//RedirectStandardInput = true,
			//RedirectStandardOutput = true,
			UseShellExecute = true,
			WorkingDirectory = Environment.CurrentDirectory,
			Verb = "runas",
			//WindowStyle = ProcessWindowStyle.Hidden
		};
		foreach (var arg in Environment.GetCommandLineArgs().Skip(1))
		{
			startInfo.ArgumentList.Add(arg);
		}
		startInfo.Verb = "runas";
		var process = new Process() { StartInfo = startInfo };

		process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
		process.ErrorDataReceived += (sender, e) => Console.Error.WriteLine(e.Data);

		process.Start();
		//process.BeginOutputReadLine();
		//process.BeginErrorReadLine();
		process.WaitForExit();

		return process.ExitCode;
	}
}

internal interface IRelaunchAsElevated
{
	int RelaunchAsElevated();
}
