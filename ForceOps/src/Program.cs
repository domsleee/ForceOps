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
			app.Run();

			return 0;
		}
		catch (System.IO.FileNotFoundException ex)
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

	/// <summary>
	/// Delete files or a directories recursively.
	/// </summary>
	/// <param name="fileOrDirectories">Files or directories to delete.</param>
	/// <param name="force">-f, Ignore nonexistent files and arguments.</param>
	/// <param name="disableElevate">-e, Do not attempt to elevate if the file can't be deleted.</param>
	/// <param name="retryDelay">-d, Delay when retrying to delete a file, after deleting processes holding a lock.</param>
	/// <param name="maxRetries">-n, Number of retries when deleting a locked file.</param>
	public void Delete(
		[Argument] string[] fileOrDirectories,
		[Option('f')] bool force = false,
		[Option('e')] bool disableElevate = false,
		[Option('d')] int retryDelay = 50,
		[Option('n')] int maxRetries = 10)
	{
		_forceOps.DeleteCommand(fileOrDirectories, force, disableElevate, retryDelay, maxRetries);
	}

	/// <summary>
	/// List files.
	/// </summary>
	/// <param name="fileOrDirectory">Files or directories to list.</param>
	public void List([Argument] string fileOrDirectory)
	{
		_forceOps.ListCommand(fileOrDirectory);
	}
}
