using ForceOps.Lib;
using Moq;
using Serilog;

namespace ForceOps.Test;

public class TestContext
{
	public ForceOpsContext forceOpsContext;
	public Mock<IElevateUtils> elevateUtilsMock = new();
	public Mock<IRelaunchAsElevated> relaunchAsElevatedMock = new();
	public Mock<IEnvironmentExit> environmentExitMock = new();
	public FakeLoggerFactory fakeLoggerFactory = new();

	public ExitCode? friendlyExitCode;
	public string? friendlyExitMessage;

	public TestContext()
	{
		elevateUtilsMock.Setup(t => t.IsProcessElevated()).Returns(false);
		relaunchAsElevatedMock.Setup(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>())).Returns(1);
		environmentExitMock
			.Setup(t => t.Exit(It.IsAny<int>(), It.IsAny<string>()))
			.Callback((int exitCode, string exitMessage) =>
		{
			friendlyExitCode = (ExitCode)exitCode;
			friendlyExitMessage = exitMessage;
		});

		forceOpsContext = new ForceOpsContext(
			elevateUtils: elevateUtilsMock.Object,
			loggerFactory: fakeLoggerFactory,
			relaunchAsElevated: relaunchAsElevatedMock.Object,
			environmentExit: environmentExitMock.Object
		);
	}
}

public class FakeLoggerFactory : ILoggerFactory
{
	public readonly List<string> Logs = new();

	public ILogger CreateLogger<T>()
	{
		var logger = new Mock<ILogger>();
		logger.Setup(t => t.Information(It.IsAny<string>())).Callback<string>(line => { Logs.Add(line); });
		return logger.Object;
	}

	public string GetAllLogsString()
	{
		return string.Join(Environment.NewLine, Logs);
	}
}
