using ForceOps.src;
using Moq;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;
public class ProgramTest : IDisposable
{
	List<IDisposable> disposables = new List<IDisposable>();
	string tempDirectoryPath;

	[Fact]
	public void ExceptionsBubble()
	{
		using var launchedProcess = LaunchCMDInDirectory(tempDirectoryPath);
		var launchAsElevatedMock = new Mock<IRelaunchAsElevated>();
		Program.relaunchAsElevated = launchAsElevatedMock.Object;
		Program.forceOpsContext.maxRetries = 0;
		Program.forceOpsContext.processKiller = new Moq.Mock<IProcessKiller>().Object;
		var exceptionWithNoRetries = Record.Exception(() => Program.DeleteCommand(new[] { tempDirectoryPath }));
		Assert.IsType<AggregateException>(exceptionWithNoRetries);
		launchAsElevatedMock.Verify(t => t.RelaunchAsElevated(), Times.Once());
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
