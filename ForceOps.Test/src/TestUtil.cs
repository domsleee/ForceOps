using System.Diagnostics;
using System.Reactive.Disposables;

namespace ForceOps.Test;
public static class TestUtil
{
	public static IDisposable LaunchCMDInDirectory(string workingDirectory)
	{
		var startInfo = new ProcessStartInfo();
		var process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "cmd",
				WorkingDirectory = workingDirectory,
				Arguments = "/c \"echo loaded\" & timeout -T 5000 -nobreak",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			}
		};
		string output = "";
		process.OutputDataReceived += (sender, e) =>
		{
			output += e.Data;
		};
		string error = "";
		process.ErrorDataReceived += (sender, e) =>
		{
			error += e.Data;
		};
		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();

		var startTime = DateTime.Now;

		while (!output.StartsWith("loaded") && !process.HasExited)
		{
			Thread.Sleep(50);
			if (DateTime.Now.Subtract(startTime).TotalSeconds > 2) {
				throw new Exception("Gave up after waiting 2 seconds");
			}
		}
		
		if (process.HasExited)
		{
			throw new Exception($"Process has exited unexpectedly.\nOutput: {output}\nError: {error}");
		}

		return Disposable.Create(() =>
		{
			process.Kill();
			process.WaitForExit(1);
		});
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
