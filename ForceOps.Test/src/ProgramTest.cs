using ForceOps.src;
using Moq;
using System.Reactive.Disposables;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;
public class ProgramTest : IDisposable
{
	List<IDisposable> disposables = new List<IDisposable>();
	string tempDirectoryPath;

	[Fact]
	public void ExceptionsBubble()
	{
		var process = LaunchCMDInDirectory(tempDirectoryPath);
		disposables.Add(Disposable.Create(() =>
		{
			process?.Kill();
			process?.WaitForExit();
		}));

		var launchAsElevatedMock = new Mock<IRelaunchAsElevated>();
		Program.relaunchAsElevated = launchAsElevatedMock.Object;
		Program.forceOpsContext.maxRetries = 0;
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
