using ForceOps.Lib;
using static ForceOps.Test.TestUtil;

namespace ForceOps.Test;

public class ForceOpsMethodsTest : IDisposable
{
	readonly List<IDisposable> disposables = new();
	readonly ForceOpsContext forceOpsContext;
	readonly FileAndFolderDeleter fileAndFolderDeleter;
	readonly string tempFolderPath;

	[Fact]
	public void DeletingDirectoryOpenInCMDWindow()
	{
		using var launchedProcess = LaunchCMDInDirectory(tempFolderPath);

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndFolderDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		Assert.StartsWith("The process cannot access the file", exceptionWithNoRetries.Message);
		forceOpsContext.maxRetries = 3;
		var exceptionWithDirectoryStrategy = Record.Exception(() => fileAndFolderDeleter.DeleteDirectory(new DirectoryInfo(tempFolderPath)));
		Assert.Null(exceptionWithDirectoryStrategy);
	}

	[Fact]
	public void DeletingFile()
	{
		using var launchedProcess = LaunchCMDInDirectory(tempFolderPath);
		var tempFilePath = GetTemporaryFileName();
		File.Open(tempFilePath, FileMode.OpenOrCreate);

		forceOpsContext.maxRetries = 0;
		var exceptionWithNoRetries = Record.Exception(() => fileAndFolderDeleter.DeleteFile(new FileInfo(tempFilePath)));
		Assert.IsType<IOException>(exceptionWithNoRetries);
		var ioException = exceptionWithNoRetries as IOException;
	}

	public ForceOpsMethodsTest()
	{
		tempFolderPath = GetTemporaryFileName();
		disposables.Add(CreateTemporaryDirectory(tempFolderPath));
		var testContext = TestUtil.CreateTestContext();
		forceOpsContext = testContext.forceOpsContext;
		fileAndFolderDeleter = new FileAndFolderDeleter(forceOpsContext);
	}

	void IDisposable.Dispose()
	{
		foreach (var disposable in disposables.AsEnumerable().Reverse())
		{
			disposable.Dispose();
		}
	}
}