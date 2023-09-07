using System.Diagnostics;

namespace ForceOps.Lib;

public static class TeeCommand
{
	static readonly TimeSpan maxWaitForFileToExistTime = TimeSpan.FromSeconds(30);

	public static void TeeFile(Process process, string file)
	{
		WaitForFileToExist(file);
		using var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using var reader = new StreamReader(fileStream);
		while (true)
		{
			var line = reader.ReadLine();
			if (line != null)
			{
				Console.WriteLine(line);
			}
			else
			{
				var exited = process.WaitForExit(100);
				if (exited) return;
			}
		}
	}

	static bool WaitForFileToExist(string file)
	{
		var sw = new Stopwatch();
		while (true)
		{
			if (File.Exists(file))
			{
				return true;
			}
			Thread.Sleep(100);
			if (sw.Elapsed > maxWaitForFileToExistTime) break;
		}
		throw new InvalidOperationException($"Gave up waiting for log file after {sw.Elapsed} time");
	}
}