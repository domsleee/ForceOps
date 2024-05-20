using System.Diagnostics;
using System.Reactive.Disposables;

namespace ForceOps.Test;

public static class TestUtil
{
	public static WrappedProcess LaunchProcessInDirectory(string workingDirectory)
	{
		return LaunchPowershellWithCommand(workingDirectory: workingDirectory);
	}

	public static WrappedProcess HoldLockOnFileUsingPowershell(string filePath)
	{
		return LaunchPowershellWithCommand(command: $"$file = [System.IO.File]::Open('{filePath}', 'CreateNew')");
	}

	static WrappedProcess LaunchPowershellWithCommand(string command = "", string workingDirectory = "")
	{
		var process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "powershell",
				WorkingDirectory = workingDirectory,
				Arguments = $"-NoProfile -Command \"$ErrorActionPreference='stop'; {command}; echo 'process has been loaded'; sleep 10000\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			}
		};

		StartProcessUntilProcessHasBeenLoadedMessage(process);

		return new WrappedProcess(process);
	}

	static void StartProcessUntilProcessHasBeenLoadedMessage(Process process)
	{
		string output = "";
		string error = "";
		process.OutputDataReceived += (sender, e) =>
		{
			if (e.Data != null) output += $"{e.Data}{System.Environment.NewLine}";
		};
		process.ErrorDataReceived += (sender, e) =>
		{
			if (e.Data != null) error += $"{e.Data}{System.Environment.NewLine}";
		};

		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();

		var startTime = DateTime.Now;

		while (!output.Contains("process has been loaded") && !process.HasExited)
		{
			Thread.Sleep(50);
			if (DateTime.Now.Subtract(startTime).TotalSeconds > 5)
			{
				throw new Exception($"Gave up after waiting 5 seconds.\nOutput: {output}\nError: {error}");
			}
		}

		if (process.HasExited)
		{
			throw new Exception($"Process has exited unexpectedly.\nOutput: {output}\nError: {error}");
		}
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
