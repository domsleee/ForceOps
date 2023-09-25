using System.Reflection;
using System.Text;
using ForceOps.Lib;
using Moq;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public sealed class ProgramTest : IDisposable
{
	readonly List<IDisposable> disposables = new();
	readonly string tempDirectoryPath;
	readonly StringBuilder stdoutStringBuilder = new();

	[Fact]
	public void ExceptionThrownIfChildFails()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;

		var forceOps = new ForceOps(new[] { "delete", tempDirectoryPath }, testContext.forceOpsContext);
		Assert.Equal(1, forceOps.Run());

		Assert.IsType<AggregateException>(forceOps.caughtException);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public void SuccessfulChildDoesntThrowException()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.relaunchAsElevatedMock.Setup(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>())).Returns(0);
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;

		var forceOps = new ForceOps(new[] { "delete", tempDirectoryPath }, testContext.forceOpsContext);
		Assert.Equal(0, forceOps.Run());

		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public void ExceptionThrownIfAlreadyElevated()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;
		testContext.elevateUtilsMock.Setup(t => t.IsProcessElevated()).Returns(true);

		var forceOps = new ForceOps(new[] { "delete", tempDirectoryPath }, testContext.forceOpsContext);
		Assert.Equal(1, forceOps.Run());

		Assert.IsType<IOException>(forceOps.caughtException);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public void RelaunchedProgramWorks()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;

		string exeNameOverride = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "forceops.exe");
		testContext.forceOpsContext.relaunchAsElevated = new RelaunchAsElevated() { verb = "", exeNameOverride = exeNameOverride };
		var forceOps = new ForceOps(new[] { "delete", tempDirectoryPath }, testContext.forceOpsContext);
		var stdoutString = GetStdoutString(stdoutStringBuilder);
		Assert.True(0 == forceOps.Run(), forceOps.caughtException?.ToString() + testContext.fakeLoggerFactory.GetAllLogsString() + stdoutString);
		Assert.True(!Directory.Exists(tempDirectoryPath), "Deleted by relaunch");
		Assert.Contains("Unable to perform operation as an unelevated process. Retrying as elevated and logging to", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	[Fact]
	public void RelaunchedProgramUsesForceDelete()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var pathThatCanBeDeleted = GetTemporaryFileName();
		disposables.Add(CreateTemporaryDirectory(pathThatCanBeDeleted));
		var testContext = new TestContext();
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;

		string exeNameOverride = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "forceops.exe");
		testContext.forceOpsContext.relaunchAsElevated = new RelaunchAsElevated() { verb = "", exeNameOverride = exeNameOverride };
		var forceOps = new ForceOps(new[] { "delete", pathThatCanBeDeleted, tempDirectoryPath }, testContext.forceOpsContext);
		forceOps.extraRelaunchArgs = new List<string>() { "--disable-elevate" };
		Assert.True(0 == forceOps.Run(), forceOps.caughtException?.ToString());
		Assert.True(!Directory.Exists(tempDirectoryPath), "Deleted by relaunch");
		Assert.Contains("Unable to perform operation as an unelevated process. Retrying as elevated and logging to", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	[Fact]
	public void DeleteNonExistingFileThrowsMessage()
	{
		var testContext = new TestContext();
		var forceOps = new ForceOps(new[] { "delete", @"C:\C:\C:\" }, testContext.forceOpsContext);
		forceOps.Run();
		Assert.Equal(ExitCode.FileNotFound, testContext.friendlyExitCode);
		Assert.Equal(@"Cannot remove 'C:\C:\C:\'. No such file or directory", testContext.friendlyExitMessage);
	}

	[Fact]
	public void ListNonExistingFileThrowsMessage()
	{
		var testContext = new TestContext();
		var forceOps = new ForceOps(new[] { "list", @"C:\C:\C:\" }, testContext.forceOpsContext);
		forceOps.Run();
		Assert.Equal(ExitCode.FileNotFound, testContext.friendlyExitCode);
		Assert.Equal(@"Cannot list locks of 'C:\C:\C:\'. No such file or directory", testContext.friendlyExitMessage);
	}

	public ProgramTest()
	{
		tempDirectoryPath = GetTemporaryFileName();
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
