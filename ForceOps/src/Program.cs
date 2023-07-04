using System.CommandLine;
using System.Runtime.Versioning;
using ForceOps.Lib;
using Serilog;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	internal static ForceOpsContext forceOpsContext = new();
	static readonly ILogger logger = forceOpsContext.loggerFactory.CreateLogger<Program>();
	internal static bool CanRelaunchAsElevated = true;

	static int Main(string[] args)
	{
		var rootCommand = new RootCommand("By hook or by crook, perform operations on files and directories. If they are in use by a process, kill the process.") { Name = "forceops" };

		var filesToDeleteArgument = new Argument<string[]>(
			name: "files",
			description: "Files or directories to delete.")
		{
			Arity = ArgumentArity.OneOrMore
		};
		var deleteCommand = new Command("delete", "Delete files or a directories recursively.") { filesToDeleteArgument };
		deleteCommand.AddAlias("rm");
		deleteCommand.SetHandler(DeleteCommand, filesToDeleteArgument);
		rootCommand.AddCommand(deleteCommand);

		return rootCommand.Invoke(args);
	}

	internal static void DeleteCommand(string[] filesOrDirectoriesToDelete)
	{
		RunWithRelaunchAsElevated(() =>
		{
			var deleter = new FileAndDirectoryDeleter(forceOpsContext);
			filesOrDirectoriesToDelete = filesOrDirectoriesToDelete.Select(file => DirectoryUtils.CombineWithCWDAndGetAbsolutePath(file)).ToArray();
			foreach (var file in filesOrDirectoriesToDelete)
			{
				deleter.DeleteFileOrDirectory(file);
			}
		});
	}

	static void RunWithRelaunchAsElevated(Action action)
	{
		try
		{
			action();
		}
		catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) && !forceOpsContext.elevateUtils.IsProcessElevated())
		{
			logger.Information("Unable to perform operation as an unelevated process. Retrying as elevated.");
			var childProcessExitCode = forceOpsContext.relaunchAsElevated.RelaunchAsElevated();
			if (childProcessExitCode != 0)
			{
				logger.Information($"Failed with exit code {childProcessExitCode}");
				throw new AggregateException($"Child process failed with {childProcessExitCode}. See inner exception for the previous exception.", ex);
			} else
			{
				logger.Information("Successfully deleted as admin");
			}
		}
	}
}