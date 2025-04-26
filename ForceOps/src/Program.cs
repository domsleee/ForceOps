using System.Runtime.Versioning;
using Cocona;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args) => new ForceOpsRunner(new ForceOps(args)).Run();
}

internal class ForceOpsRunner
{
	readonly ForceOps _forceOps;
	int exitCode = 0;
	public ForceOpsRunner(ForceOps forceOps)
	{
		_forceOps = forceOps;
	}

	internal int Run()
	{
		var app = CoconaLiteApp.Create(_forceOps.args);
		app.AddCommand("delete", (
			[Argument("files", Description = "Files or directories to delete.")] string[] fileOrDirectories,
			[Option('f', Description = "Ignore nonexistent files and arguments.")] bool force = false,
			[Option('e', Description = "Do not attempt to elevate if the file can't be deleted.")] bool disableElevate = false,
			[Option('d', Description = "Delay when retrying to delete a file, after deleting processes holding a lock.")] int retryDelay = 50,
			[Option('n', Description = "Number of retries when deleting a locked file.")] int maxRetries = 10)
			=> WithExceptionHandling(() => _forceOps.DeleteCommand(fileOrDirectories, force, disableElevate, retryDelay, maxRetries))
		)
		.WithDescription("Delete files or a directories recursively.")
		.WithAliases(["rm"]);

		app.AddCommand("list", (
			[Argument("fileOrDirectory", Description = "File or directory to get the locks of.")] string fileOrDirectory)
			=> WithExceptionHandling(() => _forceOps.ListCommand(fileOrDirectory))
		)
		.WithDescription("Uses LockCheck to output processes using a file or directory.");

		app.Run();
		return exitCode;
	}

	void WithExceptionHandling(Action action)
	{
		try
		{
			action();
		}
		catch (FileNotFoundException ex)
		{
			_forceOps.caughtException = ex;
			_forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
			exitCode = (int)ExitCode.FileNotFound;
		}
		catch (Exception ex)
		{
			_forceOps.caughtException = ex;
			exitCode = 1;
		}
	}
}
