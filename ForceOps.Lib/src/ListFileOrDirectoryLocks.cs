using LockCheck;
using Serilog;
using static LockCheck.LockManager;

namespace ForceOps.Lib;

public class ListFileOrDirectoryLocks
{
	readonly ILogger logger;
	readonly ForceOpsContext forceOpsContext;

	public ListFileOrDirectoryLocks(ForceOpsContext forceOpsContext, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext;
		this.logger = logger ?? forceOpsContext.loggerFactory.CreateLogger<ListFileOrDirectoryLocks>();
	}

	/// <summary>
	/// Uses LockCheck to output processes using a file or directory.
	/// </summary>
	/// <param name="fileOrDirectory"></param>
	public void PrintLocks(string fileOrDirectory)
	{
		var processInfos = GetLocks(fileOrDirectory);
		var columns = new (string columnName, Func<ProcessInfo, string?> getColumn)[]
		{
			("ProcessId", ProcessInfo => ProcessInfo?.ProcessId.ToString()),
			("ExecutableName", ProcessInfo => ProcessInfo?.ExecutableName),
			("ApplicationName", ProcessInfo => ProcessInfo?.ApplicationName),
		};

		Console.WriteLine(string.Join(",", columns.Select(col => col.columnName)));
		foreach (var processInfo in processInfos)
		{
			Console.WriteLine(string.Join(",", columns.Select(col => col.getColumn(processInfo) ?? "<null>")));
		}
	}

	public IEnumerable<LockCheck.ProcessInfo> GetLocks(string fileOrDirectory)
	{
		if (Directory.Exists(fileOrDirectory))
		{
			return GetLockingProcessInfos(new[] { fileOrDirectory }, LockManagerFeatures.UseLowLevelApi);
		}
		if (File.Exists(fileOrDirectory))
		{
			return GetLockingProcessInfos(new[] { fileOrDirectory });
		}

		throw new FileNotFoundException($"Cannot list locks of '{fileOrDirectory}'. No such file or directory");
	}
}