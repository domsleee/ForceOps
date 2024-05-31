using System.Diagnostics;
using System.Reflection;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public class DeleteExampleTest
{
	[Fact]
	public void DeleteExampleWorks()
	{
		var tempFilePath = GetTemporaryFileName();
		using var launchedProcess = HoldLockOnFileUsingPowershell(tempFilePath);
		var process = Process.Start(new ProcessStartInfo
		{
			FileName = GetDeleteExampleExePath(),
			Arguments = tempFilePath,
			RedirectStandardOutput = true
		})!;

		var standardOutput = process.StandardOutput.ReadToEnd();
		process.WaitForExit();
		Assert.Equal(0, process.ExitCode);
		Assert.False(File.Exists(tempFilePath));
		Assert.Contains("INF] Could not delete file", standardOutput);
	}

	private static string GetDeleteExampleExePath()
	{
		var currentAssemblyPath = Assembly.GetExecutingAssembly().Location;
		var currentDirectory = Path.GetDirectoryName(currentAssemblyPath)!;
		var deleteExampleExe = Path.Combine(currentDirectory.Replace("ForceOps.Test", "ForceOps.DeleteExample"), "ForceOps.DeleteExample.exe");

		if (!File.Exists(deleteExampleExe))
		{
			throw new FileNotFoundException($"{deleteExampleExe} did not exist.");
		}

		return deleteExampleExe;
	}
}
