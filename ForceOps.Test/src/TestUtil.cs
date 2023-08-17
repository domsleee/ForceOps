using System.Diagnostics;
using System.Reactive.Disposables;

namespace ForceOps.Test;

public static class TestUtil
{
	public static IDisposable LaunchProcessInDirectory(string workingDirectory)
	{
		return LaunchPowershellWithCommand(workingDirectory: workingDirectory);
	}

	public static IDisposable HoldLockOnFileUsingPowershell(string filePath)
	{
		return LaunchPowershellWithCommand(command: $"[System.IO.File]::Open('{filePath}', 'OpenOrCreate')");
	}

	public static IDisposable LaunchPowershellWithCommand(string command = "", string workingDirectory = "")
	{
		var process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "powershell",
				WorkingDirectory = workingDirectory,
				Arguments = $"-NoProfile -Command \"{command}; echo 'process has been loaded'; sleep 10000\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			}
		};

		List<string> output = new();
		List<string> error = new();
		process.OutputDataReceived += (sender, e) =>
		{
			if (e.Data != null) output.Add(e.Data);
		};
		process.ErrorDataReceived += (sender, e) =>
		{
			if (e.Data != null) error.Add(e.Data);
		};

		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();

		var startTime = DateTime.Now;

		while (!(output.LastOrDefault() ?? "").EndsWith("process has been loaded") && !process.HasExited)
		{
			Thread.Sleep(50);
			if (DateTime.Now.Subtract(startTime).TotalSeconds > 5)
			{
				throw new Exception("Gave up after waiting 5 seconds");
			}
		}

		if (process.HasExited)
		{
			throw new Exception($"Process has exited unexpectedly.\nOutput: {string.Join("\n", output)}\nError: {string.Join("\n", error)}");
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
