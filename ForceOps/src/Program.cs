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

		var filesToDeleteArg = new Argument<string[]>(
			name: "files",
			description: "Files or directories to delete.")
		{
			Arity = ArgumentArity.OneOrMore
		};
		var deleteCommand = new Command("delete", "Delete files or a directories recursively.") { filesToDeleteArg };
		deleteCommand.AddAlias("rm");
		deleteCommand.SetHandler(DeleteCommand, filesToDeleteArg);
		rootCommand.AddCommand(deleteCommand);

		var sourceFileNameArg = new Argument<string>(
			name: "sourceFileName",
			description: "Source file or directory to move");
		var destFileNameArg = new Argument<string>(
			name: "destFileName",
			description: "Destination for the file or folder");

		var moveCommand = new Command("move", "Move a file or a directory") { sourceFileNameArg, destFileNameArg };
		moveCommand.SetHandler(MoveCommand, sourceFileNameArg, destFileNameArg);
		moveCommand.AddAlias("mv");
		rootCommand.AddCommand(moveCommand);

		return rootCommand.Invoke(args);
	}

	internal static void DeleteCommand(string[] filesOrDirectoriesToDelete)
	{
		RunWithRelaunchAsElevated(() =>
		{
			filesOrDirectoriesToDelete = filesOrDirectoriesToDelete.Select(file => Path.Combine(Environment.CurrentDirectory, file)).ToArray();
			var deleter = new FileAndDirectoryDeleter(forceOpsContext);
			foreach (var file in filesOrDirectoriesToDelete)
			{
				deleter.DeleteFileOrDirectory(file);
			}
		});
	}

	internal static void MoveCommand(string sourceFileName, string destFileName)
	{
		RunWithRelaunchAsElevated(() =>
		{
			sourceFileName = Path.Combine(Environment.CurrentDirectory, sourceFileName);
			destFileName = Path.Combine(Environment.CurrentDirectory, destFileName);
			var mover = new FileAndDirectoryMover(forceOpsContext);
			mover.MoveFileOrDirectory(sourceFileName,  destFileName);
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