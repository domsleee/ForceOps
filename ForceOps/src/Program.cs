using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Runtime.Versioning;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args) => new ForceOpsRunner(new ForceOps(args)).Run();
}

internal class ForceOpsRunner
{
	readonly ForceOps _forceOps;
	public ForceOpsRunner(ForceOps forceOps)
	{
		_forceOps = forceOps;
	}

	internal int Run()
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
					_forceOps.caughtException = ex;

					if (ex is FileNotFoundException fileNotFoundEx)
					{
						_forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
					}
					throw;
				}
			})
			.Build();

		return parser.Invoke(_forceOps.args);
	}

	Command CreateDeleteCommand()
	{
		var filesToDeleteArgument = new Argument<string[]>("files", "Files or directories to delete.")
		{
			Arity = ArgumentArity.OneOrMore
		};

		var forceOption = new Option<bool>(["-f", "--force"], "Ignore nonexistent files and arguments.");
		var disableElevate = new Option<bool>(["-e", "--disable-elevate"], "Do not attempt to elevate if the file can't be deleted.");
		var retryDelay = new Option<int>(["-d", "--retry-delay"], () => 50, "Delay when retrying to delete a file, after deleting processes holding a lock.");
		var maxRetries = new Option<int>(["-n", "--max-retries"], () => 10, "Number of retries when deleting a locked file.");

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
		deleteCommand.SetHandler(_forceOps.DeleteCommand, filesToDeleteArgument, forceOption, disableElevate, retryDelay, maxRetries);
		return deleteCommand;
	}

	Command CreateListCommand()
	{
		var fileOrDirectoryArgument = new Argument<string>("fileOrDirectory", "File or directory to get the locks of.");
		var listCommand = new Command("list", "Uses LockCheck to output processes using a file or directory.")
		{
			fileOrDirectoryArgument
		};
		listCommand.SetHandler(_forceOps.ListCommand, fileOrDirectoryArgument);
		return listCommand;
	}
}
