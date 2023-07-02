﻿using Moq;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public sealed class ProgramTest : IDisposable
{
	readonly List<IDisposable> disposables = new();
	readonly string tempDirectoryPath;

	[Fact]
	public void ExceptionsBubble()
	{
		using var launchedProcess = LaunchCMDInDirectory(tempDirectoryPath);
		var testContext = CreateTestContext();
		Program.forceOpsContext = testContext.forceOpsContext;
		Program.forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => Program.DeleteCommand(new[] { tempDirectoryPath }));
		Assert.IsType<AggregateException>(exceptionWithNoRetries);
		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(), Times.Once());
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
