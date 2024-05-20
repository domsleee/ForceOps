using System.Text;
using ForceOps.Lib;
using static ForceOps.Test.TestUtil;
using static ForceOps.Test.TestUtilStdout;

namespace ForceOps.Test;

public class ListFileOrDirectoryLocksTest : IDisposable
{
	readonly string tempDirectoryPath = GetTemporaryFileName();
	readonly StringBuilder stdoutStringBuilder = new();
	readonly List<IDisposable> disposables = new();

	[Fact]
	public void WorksForDirectory()
	{
		var testContext = new TestContext();
		using var launchedProcess = LaunchProcessInDirectory(workingDirectory: tempDirectoryPath);
		new ListFileOrDirectoryLocks(testContext.forceOpsContext).PrintLocks(tempDirectoryPath);

		var stdoutString = GetStdoutString(stdoutStringBuilder);
		Assert.Contains($"ProcessId,ExecutableName,ApplicationName\r\n{launchedProcess.process.Id},powershell.exe,powershell.exe\r\n", stdoutString);
	}

	[Fact]
	public void WorksForFile()
	{
		var testContext = new TestContext();
		var tempFilePath = GetTemporaryFileName();
		using var launchedProcess = HoldLockOnFileUsingPowershell(tempFilePath);
		new ListFileOrDirectoryLocks(testContext.forceOpsContext).PrintLocks(tempFilePath);

		var stdoutString = GetStdoutString(stdoutStringBuilder);
		Assert.False(launchedProcess.process.HasExited);
		Assert.Equal($"ProcessId,ExecutableName,ApplicationName\r\n{launchedProcess.process.Id},powershell.exe,powershell.exe\r\n", stdoutString);
	}

	public ListFileOrDirectoryLocksTest()
	{
		disposables.Add(CreateTemporaryDirectory(tempDirectoryPath));
		disposables.Add(RedirectStdout(stdoutStringBuilder));
	}

	void IDisposable.Dispose()
	{
		foreach (var disposable in disposables.AsEnumerable().Reverse())
		{
			disposable.Dispose();
		}
	}
}
