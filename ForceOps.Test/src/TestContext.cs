using ForceOps.Lib;
using Moq;
using Serilog;

namespace ForceOps.Test;

public class TestContext
{
	public ForceOpsContext forceOpsContext;
	public Mock<IElevateUtils> elevateUtilsMock;
	public Mock<IRelaunchAsElevated> relaunchAsElevatedMock;
	public FakeLoggerFactory fakeLoggerFactory;

	public TestContext()
	{
		elevateUtilsMock = new Mock<IElevateUtils>();
		elevateUtilsMock.Setup(t => t.IsProcessElevated()).Returns(false);
		relaunchAsElevatedMock = new Mock<IRelaunchAsElevated>();
		fakeLoggerFactory = new FakeLoggerFactory();

		forceOpsContext = new ForceOpsContext(elevateUtils: elevateUtilsMock.Object, loggerFactory: fakeLoggerFactory, relaunchAsElevated: relaunchAsElevatedMock.Object);
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
