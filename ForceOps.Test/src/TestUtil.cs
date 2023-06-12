using System.Diagnostics;
using System.Reactive.Disposables;

namespace ForceOps.Test;
public static class TestUtil
{
	public static Process? LaunchCMDInDirectory(string workingDirectory)
	{
		ProcessStartInfo startInfo = new ProcessStartInfo();
		var process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = "cmd",
			WorkingDirectory = workingDirectory,
			Arguments = "/c \"echo loaded\" & pause",
			RedirectStandardOutput = true,
			CreateNoWindow = true
		};
		string output = "";
		process.OutputDataReceived += (sender, e) =>
		{
			output += e.Data;
		};
		process.Start();
		process.BeginOutputReadLine();

		while (!output.StartsWith("loaded"))
		{
			Thread.Sleep(50);
		}
		return process;
	}

	public static string GetTemporaryFileName()
	{
		return Path.Join(Path.GetTempPath(), Guid.NewGuid().ToString());
	}

	public static IDisposable CreateTemporaryDirectory(string directory)
	{
		Directory.CreateDirectory(directory);
		return Disposable.Create(() =>
		{
			try
			{
				Directory.Delete(directory);
			}
			catch { }
		});
	}
}
