using System.Runtime.Versioning;
using ConsoleAppFramework;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args) => new ForceOpsRunner(new ForceOps(args)).Run();
}

class ForceOpsRunner
{
	readonly ForceOps forceOps;
	int exitCode = 0;
	public ForceOpsRunner(ForceOps forceOps)
	{
		this.forceOps = forceOps;
	}

	public int Run()
	{
		var app = ConsoleApp.Create();
		app.Add("delete", Delete);
		app.Add("list", List);
		app.Run(forceOps.args);
		return exitCode;
	}

	/// <summary>
	/// Delete files or a directories recursively.
	/// </summary>
	/// <param name="fileOrDirectories">Files or directories to delete.</param>
	/// <param name="force">-f, Ignore nonexistent files and arguments.</param>
	/// <param name="disableElevate">-e, Do not attempt to elevate if the file can't be deleted.</param>
	/// <param name="retryDelay">-d, Delay when retrying to delete a file, after deleting processes holding a lock.</param>
	/// <param name="maxRetries">-n, Number of retries when deleting a locked file.</param>
	[Command("delete")]
	public void Delete([Argument] string[] fileOrDirectories, bool force = false, bool disableElevate = false, int retryDelay = 50, int maxRetries = 10)
	{
		WithExceptionHandling(() => forceOps.DeleteCommand(fileOrDirectories, force, disableElevate, retryDelay, maxRetries));
	}

	/// <summary>
	/// List files.
	/// </summary>
	/// <param name="fileOrDirectory">Files or directories to list.</param>
	[Command("list")]
	public void List([Argument] string fileOrDirectory)
	{
		WithExceptionHandling(() => forceOps.ListCommand(fileOrDirectory));
	}

	void WithExceptionHandling(Action action)
	{
		try
		{
			action();
		}
		catch (Exception ex)
		{
			exitCode = 1;
			forceOps.caughtException = ex;

			if (ex is FileNotFoundException fileNotFoundEx)
			{
				forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
			}
			throw;
		}
	}
}
