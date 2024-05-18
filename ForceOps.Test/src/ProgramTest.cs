using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
	public void RetryDelayAndMaxRetriesWork()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempDirectoryPath);
		var testContext = new TestContext();
		testContext.relaunchAsElevatedMock.Setup(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>())).Returns(0);
		testContext.forceOpsContext.processKiller = new Mock<IProcessKiller>().Object;

		var forceOps = new ForceOps(new[] { "delete", tempDirectoryPath, "--retry-delay", "33", "--max-retries", "8" }, testContext.forceOpsContext);
		Assert.Equal(0, forceOps.Run());

		testContext.relaunchAsElevatedMock.Verify(t => t.RelaunchAsElevated(It.IsAny<List<string>>(), It.IsAny<string>()), Times.Once());
		Assert.Contains("Beginning retry 1/8 in 33ms.", testContext.fakeLoggerFactory.GetAllLogsString());
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
		Assert.True(0 == forceOps.Run(), BuildFailMessage(testContext, forceOps, stdoutString));
		Assert.True(!Directory.Exists(tempDirectoryPath), "Deleted by relaunch");
		Assert.Contains("Unable to perform operation as an unelevated process. Retrying as elevated and logging to", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	string BuildFailMessage(TestContext testContext, ForceOps forceOps, string stdoutString)
	{
		var sb = new StringBuilder();
		sb.AppendLine("Caught Exception");
		sb.AppendLine("======");
		sb.Append(forceOps.caughtException?.ToString());
		sb.AppendLine();

		sb.AppendLine("LogFactory Logs");
		sb.AppendLine("======");
		var logFactoryLogsString = testContext.fakeLoggerFactory.GetAllLogsString();
		sb.AppendLine(logFactoryLogsString);
		sb.AppendLine();

		sb.AppendLine("stdoutString");
		sb.AppendLine("======");
		sb.AppendLine(stdoutString);
		sb.AppendLine();

		sb.AppendLine("elevatedLogs");
		sb.AppendLine("======");
		// logFactoryLogsString has a line like this:
		// Retrying as elevated and logging to "C:\Users\user\AppData\Local\Temp\tmpneo0gl.tmp"
		// Extract that line using regex, and output the logs hhere.
		var match = Regex.Match(logFactoryLogsString, @"Retrying as elevated and logging to ""(.+)""");
		if (match.Success)
		{
			var elevatedLogFilePath = match.Groups[1].Value;
			sb.AppendLine($"Log file: {elevatedLogFilePath}");
			try
			{
				sb.AppendLine(File.ReadAllText(elevatedLogFilePath));
			}
			catch (Exception ex)
			{
				sb.AppendLine($"Error reading elevated logs: {ex.Message}");
			}
		}
		else
		{
			sb.AppendLine("No elevated log file path found.");
		}

		return sb.ToString();
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
