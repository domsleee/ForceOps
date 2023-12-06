using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using ForceOps.Lib;
using Serilog;

namespace ForceOps;

internal class ForceOps
{
	readonly internal ForceOpsContext forceOpsContext = new();
	readonly ILogger logger;
	readonly string[] args;
	internal Exception? caughtException = null;
	internal List<string>? extraRelaunchArgs = null;

	public ForceOps(string[] args, ForceOpsContext? forceOpsContext = null, ILogger? logger = null)
	{
		this.forceOpsContext = forceOpsContext ?? new ForceOpsContext();
		this.logger = logger ?? this.forceOpsContext.loggerFactory.CreateLogger<ForceOps>();
		this.args = args;
	}

	public int Run()
	{
		var rootCommand = new RootCommand("By hook or by crook, perform operations on files and directories. If they are in use by a process, kill the process.")
		{
			Name = "forceops"
		};
		rootCommand.AddCommand(CreateDeleteCommand());
		rootCommand.AddCommand(CreateListCommand());

		var parser = new CommandLineBuilder(rootCommand)
			.UseDefaults()
			.AddMiddleware(async (context, next) =>
			{
				try
				{
					await next(context);
				}
				catch (Exception ex)
				{
					caughtException = ex;

					if (ex is FileNotFoundException fileNotFoundEx)
					{
						forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
					}
					throw;
				}
			})
			.Build();

		return parser.Invoke(args);
	}

	Command CreateDeleteCommand()
	{
		var filesToDeleteArgument = new Argument<string[]>("files", "Files or directories to delete.")
		{
			Arity = ArgumentArity.OneOrMore
		};

		var forceOption = new Option<bool>(new[] { "-f", "--force" }, "Ignore nonexistent files and arguments.");
		var disableElevate = new Option<bool>(new[] { "-e", "--disable-elevate" }, "Do not attempt to elevate if the file can't be deleted.");
		var retryDelay = new Option<int>(new[] { "-d", "--retry-delay" }, () => 500, "Delay when retrying to delete a file, after deleting processes holding a lock.");
		var maxRetries = new Option<int>(new[] { "-n", "--max-retries" }, () => 5, "Number of retries when deleting a locked file.");

		var deleteCommand = new Command("delete", "Delete files or a directories recursively.")
		{
			filesToDeleteArgument,
			forceOption,
			disableElevate,
			retryDelay,
			maxRetries
		};

		deleteCommand.AddAlias("rm");
		deleteCommand.AddAlias("remove");
		deleteCommand.SetHandler(DeleteCommand, filesToDeleteArgument, forceOption, disableElevate, retryDelay, maxRetries);
		return deleteCommand;
	}

	void DeleteCommand(string[] filesOrDirectoriesToDelete, bool force, bool disableElevate, int retryDelay, int maxRetries)
	{
		RunWithRelaunchAsElevated(() =>
		{
			forceOpsContext.maxRetries = maxRetries;
			forceOpsContext.retryDelay = TimeSpan.FromMilliseconds(retryDelay);
			var deleter = new FileAndDirectoryDeleter(forceOpsContext);
			filesOrDirectoriesToDelete = filesOrDirectoriesToDelete.Select(file => DirectoryUtils.CombineWithCWDAndGetAbsolutePath(file)).ToArray();
			foreach (var file in filesOrDirectoriesToDelete)
			{
				deleter.DeleteFileOrDirectory(file, force);
			}
		}, BuildArgsForRelaunch, disableElevate);
	}

	Command CreateListCommand()
	{
		var fileOrDirectoryArgument = new Argument<string>("fileOrDirectory", "File or directory to get the locks of.");
		var listCommand = new Command("list", "Uses LockCheck to output processes using a file or directory.")
		{
			fileOrDirectoryArgument
		};
		listCommand.SetHandler(ListCommand, fileOrDirectoryArgument);
		return listCommand;
	}

	void ListCommand(string fileOrDirectory)
	{
		new ListFileOrDirectoryLocks(forceOpsContext).PrintLocks(fileOrDirectory);
	}

	List<string> BuildArgsForRelaunch()
	{
		var newArgs = args.ToList();
		if (!newArgs.Any(arg => arg == "-f" || arg == "--force"))
		{
			newArgs.Add("-f");
		}
		if (extraRelaunchArgs != null)
		{
			newArgs.AddRange(extraRelaunchArgs);
		}
		return newArgs;
	}

	void RunWithRelaunchAsElevated(Action action, Func<List<string>> buildArgsForRelaunch, bool disableElevate)
	{
		try
		{
			action();
		}
		catch (Exception ex) when (IsExceptionCausedByPermissions(ex) && !forceOpsContext.elevateUtils.IsProcessElevated() && !disableElevate)
		{
			var args = buildArgsForRelaunch();
			var childOutputFile = GetChildOutputFile();
			args.AddRange(new[] { "2>&1", ">", childOutputFile });
			logger.Information($"Unable to perform operation as an unelevated process. Retrying as elevated and logging to \"{childOutputFile}\".");
			var childProcessExitCode = forceOpsContext.relaunchAsElevated.RelaunchAsElevated(args, childOutputFile);
			if (childProcessExitCode != 0)
			{
				throw new AggregateException($"Child process failed with {childProcessExitCode}.");
			}
			else
			{
				logger.Information("Successfully deleted as admin");
			}
		}
	}

	static string GetChildOutputFile()
	{
		return Path.GetTempFileName();
	}

	static bool IsExceptionCausedByPermissions(Exception ex)
	{
		if (ex is FileNotFoundException)
		{
			return false;
		}
		return ex is IOException || ex is UnauthorizedAccessException;
	}
}
