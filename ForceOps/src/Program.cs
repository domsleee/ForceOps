using System.Runtime.Versioning;
using ConsoleAppFramework;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	internal static string[] args;
	internal static ForceOps forceops;

	public static int Main(string[] args)
	{
		Program.args = args;
		forceops = new ForceOps();

		var app = ConsoleApp.Create();
		app.Add<MyCommands>();
		app.Run(args);

		return 0;
	}
}

public class MyCommands
{
	/// <summary>
	/// Delete files or a directories recursively.
	/// </summary>
	/// <param name="files">Files or directories to delete.</param>
	/// <param name="force">-f, Ignore nonexistent files and arguments.</param>
	/// <param name="disableElevate">-e, Do not attempt to elevate if the file can't be deleted.</param>
	/// <param name="retryDelay">-d, Delay when retrying to delete a file, after deleting processes holding a lock.</param>
	/// <param name="maxRetries">-n, Number of retries when deleting a locked file.</param>
	[Command("delete")]
	public void Delete([Argument] string[] files, bool force = false, bool disableElevate = false, int retryDelay = 50, int maxRetries = 10)
	{
		Program.forceops.DeleteCommand(files, files, force, disableElevate, retryDelay, maxRetries);
	}
}