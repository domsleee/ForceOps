using System.CommandLine;
using System.Runtime.Versioning;
using ForceOps.Lib;
using Serilog;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	static readonly ILogger logger = ForceOpsLoggerFactory.CreateLogger<Program>();
	internal static ForceOpsContext forceOpsContext = new();
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
			var deleter = new FileAndFolderDeleter(forceOpsContext);
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
			logger.Information("Received IOException or UnauthorizedAccessException when trying to get process using file or directory. Retrying as elevated.");
			var childProcessExitCode = forceOpsContext.relaunchAsElevated.RelaunchAsElevated();
			var childResultMessage = childProcessExitCode == 0
				? "Successfully deleted as admin"
				: $"Failed with exit code {childProcessExitCode}";
			logger.Information(childResultMessage);
			throw new AggregateException($"Child process failed with {childProcessExitCode}. See inner exception for local exception.", ex);
		}
	}
}