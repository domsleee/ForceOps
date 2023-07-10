using Moq;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public sealed class ProgramTest : IDisposable
{
	readonly List<IDisposable> disposables = new();
	readonly string tempDirectoryPath;

	[Fact]
	public void ExceptionThrownIfChildFails()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		Program.forceOpsContext = testContext.forceOpsContext;
		Program.forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => Program.DeleteCommand(new[] { tempDirectoryPath }));

		Assert.IsType<AggregateException>(exceptionWithNoRetries);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(), Times.Once());
	}

	[Fact]
	public void SuccessfulChildDoesntThrowException()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.relaunchAsElevatedMock.Setup(t => t.RelaunchAsElevated()).Returns(0);
		Program.forceOpsContext = testContext.forceOpsContext;
		Program.forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => Program.DeleteCommand(new[] { tempDirectoryPath }));

		Assert.Null(exceptionWithNoRetries);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(), Times.Once());
	}

	[Fact]
	public void ExceptionThrownIfAlreadyElevated()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.elevateUtilsMock.Setup(t => t.IsProcessElevated()).Returns(true);
		Program.forceOpsContext = testContext.forceOpsContext;
		Program.forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => Program.DeleteCommand(new[] { tempDirectoryPath }));

		Assert.IsType<IOException>(exceptionWithNoRetries);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(), Times.Never());
	}

	public ProgramTest()
	{
		tempDirectoryPath = GetTemporaryFileName();
		disposables.Add(CreateTemporaryDirectory(tempDirectoryPath));
	}

	void IDisposable.Dispose()
	{
		foreach (var disposable in disposables.AsEnumerable().Reverse())
		{
			disposable.Dispose();
		}
	}
}
