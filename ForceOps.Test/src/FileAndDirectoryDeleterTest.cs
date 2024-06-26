using ForceOps.Lib;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public class ForceOpsMethodsTest : IDisposable
{
	readonly List<IDisposable> disposables = new();
	readonly ForceOpsContext forceOpsContext;
	readonly FileAndDirectoryDeleter fileAndDirectoryDeleter;
	readonly string tempFolderPath;
	readonly TestContext testContext;

	[Fact]
	public void DeletingDirectoryOpenInPowershellWorkingDirectory()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempFolderPath);

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndDirectoryDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		Assert.StartsWith("The process cannot access the file", exceptionWithNoRetries.Message);

		forceOpsContext.maxRetries = 10;
		var exceptionWithDirectoryStrategy = Record.Exception(() => fileAndDirectoryDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.True(null == exceptionWithDirectoryStrategy, testContext.fakeLoggerFactory.GetAllLogsString());

		Assert.Matches(@"Exceeded retry count of 0. Failed. ForceOps process is not elevated.
Could not delete directory .*. Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: \[\d+ \- powershell.exe\]", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	[Fact]
	public void DeletingReadonlyDirectoryOpenInPowershellWorkingDirectory()
	{
		using var launchedProcess = LaunchProcessInDirectory(tempFolderPath);
		new DirectoryInfo(tempFolderPath).Attributes |= FileAttributes.ReadOnly;

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndDirectoryDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		Assert.StartsWith("The process cannot access the file", exceptionWithNoRetries.Message);

		forceOpsContext.maxRetries = 10;
		var exceptionWithDirectoryStrategy = Record.Exception(() => fileAndDirectoryDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.True(null == exceptionWithDirectoryStrategy, testContext.fakeLoggerFactory.GetAllLogsString());

		Assert.Matches(@"Exceeded retry count of 0. Failed. ForceOps process is not elevated.
Could not delete directory .*. Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: \[\d+ \- powershell.exe\]", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	[Fact]
	public void DeletingFileOpenByPowershell()
	{
		var tempFilePath = GetTemporaryFileName();
		using var launchedProcess = HoldLockOnFileUsingPowershell(tempFilePath);

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndDirectoryDeleter.DeleteFile(new FileInfo(tempFilePath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		Assert.StartsWith("The process cannot access the file", exceptionWithNoRetries.Message);

		forceOpsContext.maxRetries = 10;
		var exceptionWithDirectoryStrategy = Record.Exception(() => fileAndDirectoryDeleter.DeleteFile(new FileInfo(tempFilePath)));
		Assert.True(null == exceptionWithDirectoryStrategy, testContext.fakeLoggerFactory.GetAllLogsString());

		Assert.Matches($@"Exceeded retry count of 0. Failed. ForceOps process is not elevated.
Could not delete file .*. Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: \[\d+ \- powershell.exe\]", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	[Fact]
	public void DeletingReadonlyFileOpenByPowershell()
	{
		var tempFilePath = GetTemporaryFileName();
		using var launchedProcess = HoldLockOnFileUsingPowershell(tempFilePath);
		new FileInfo(tempFilePath).IsReadOnly = true;

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndDirectoryDeleter.DeleteFile(new FileInfo(tempFilePath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		Assert.StartsWith("The process cannot access the file", exceptionWithNoRetries.Message);

		forceOpsContext.maxRetries = 10;
		var exceptionWithDirectoryStrategy = Record.Exception(() => fileAndDirectoryDeleter.DeleteFile(new FileInfo(tempFilePath)));
		Assert.True(null == exceptionWithDirectoryStrategy, testContext.fakeLoggerFactory.GetAllLogsString());

		Assert.Matches($@"Exceeded retry count of 0. Failed. ForceOps process is not elevated.
Could not delete file .*. Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: \[\d+ \- powershell.exe\]", testContext.fakeLoggerFactory.GetAllLogsString());
	}

	public ForceOpsMethodsTest()
	{
		tempFolderPath = GetTemporaryFileName();
		disposables.Add(CreateTemporaryDirectory(tempFolderPath));
		testContext = new TestContext();
		forceOpsContext = testContext.forceOpsContext;
		fileAndDirectoryDeleter = new FileAndDirectoryDeleter(forceOpsContext);
	}

	void IDisposable.Dispose()
	{
		foreach (var disposable in disposables.AsEnumerable().Reverse())
		{
			disposable.Dispose();
		}
	}
}