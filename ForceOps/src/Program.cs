using System.Runtime.Versioning;
using Cocona;
using Cocona.Lite;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args) => new ForceOpsRunner(new ForceOps(args)).Run();
}

internal class ForceOpsRunner
{
	private readonly ForceOps _forceOps;
	public ForceOpsRunner(ForceOps forceOps)
	{
		_forceOps = forceOps;
	}

	internal int Run()
	{
		try
		{
			var builder = CoconaLiteApp.CreateBuilder(_forceOps.args);
			builder.Services.AddSingleton(_forceOps);
			var app = builder.Build();
			app.AddCommand("delete", Delete);
			app.AddCommand("list", List);
			app.Run();

			return 0;
		}
		catch (FileNotFoundException ex)
		{
			_forceOps.caughtException = ex;
			_forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
			return (int)ExitCode.FileNotFound;
		}
		catch (Exception ex)
		{
			_forceOps.caughtException = ex;
			return 1;
		}
	}

	[Command(Description = "Delete files or a directories recursively.", Aliases = ["rm"])]
	public void Delete(
		[Argument("files", Description = "Files or directories to delete.")] string[] fileOrDirectories,
		[Option('f', Description = "Ignore nonexistent files and arguments.")] bool force = false,
		[Option('e', Description = "Do not attempt to elevate if the file can't be deleted.")] bool disableElevate = false,
		[Option('d', Description = "Delay when retrying to delete a file, after deleting processes holding a lock.")] int retryDelay = 50,
		[Option('n', Description = "Number of retries when deleting a locked file.")] int maxRetries = 10)
	{
		_forceOps.DeleteCommand(fileOrDirectories, force, disableElevate, retryDelay, maxRetries);
	}

	[Command(Description = "Uses LockCheck to output processes using a file or directory.")]
	public void List([Argument("fileOrDirectory", Description = "File or directory to get the locks of.")] string fileOrDirectory)
	{
		_forceOps.ListCommand(fileOrDirectory);
	}
}
