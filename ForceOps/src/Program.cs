using System.CommandLine;
using System.CommandLine.Help;
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
		// A named Command is used instead of RootCommand so the usage text shows
		// "forceops" rather than the executable name ("ForceOps").
		var rootCommand = new Command("forceops", "By hook or by crook, perform operations on files and directories. If they are in use by a process, kill the process.");
		rootCommand.Options.Add(new HelpOption());
		rootCommand.Options.Add(new VersionOption());
		rootCommand.Subcommands.Add(CreateDeleteCommand());
		rootCommand.Subcommands.Add(CreateListCommand());

		try
		{
			return rootCommand.Parse(_forceOps.args).Invoke(new InvocationConfiguration
			{
				EnableDefaultExceptionHandler = false
			});
		}
		catch (Exception ex)
		{
			_forceOps.caughtException = ex;

			if (ex is FileNotFoundException)
			{
				_forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
			}
			Console.Error.WriteLine(ex.ToString());
			return 1;
		}
	}

	Command CreateDeleteCommand()
	{
		var filesToDeleteArgument = new Argument<string[]>("files")
		{
			Description = "Files or directories to delete.",
			Arity = ArgumentArity.OneOrMore
		};

		var forceOption = new Option<bool>("--force", "-f") { Description = "Ignore nonexistent files and arguments." };
		var disableElevate = new Option<bool>("--disable-elevate", "-e") { Description = "Do not attempt to elevate if the file can't be deleted." };
		var retryDelay = new Option<int>("--retry-delay", "-d") { DefaultValueFactory = _ => 50, Description = "Delay when retrying to delete a file, after deleting processes holding a lock." };
		var maxRetries = new Option<int>("--max-retries", "-n") { DefaultValueFactory = _ => 10, Description = "Number of retries when deleting a locked file." };

		var deleteCommand = new Command("delete", "Delete files or a directories recursively.")
		{
			filesToDeleteArgument,
			forceOption,
			disableElevate,
			retryDelay,
			maxRetries
		};

		deleteCommand.Aliases.Add("rm");
		deleteCommand.Aliases.Add("remove");
		deleteCommand.SetAction(parseResult => _forceOps.DeleteCommand(
			parseResult.GetValue(filesToDeleteArgument)!,
			parseResult.GetValue(forceOption),
			parseResult.GetValue(disableElevate),
			parseResult.GetValue(retryDelay),
			parseResult.GetValue(maxRetries)));
		return deleteCommand;
	}

	Command CreateListCommand()
	{
		var fileOrDirectoryArgument = new Argument<string>("fileOrDirectory")
		{
			Description = "File or directory to get the locks of."
		};
		var listCommand = new Command("list", "Uses LockCheck to output processes using a file or directory.")
		{
			fileOrDirectoryArgument
		};
		listCommand.SetAction(parseResult => _forceOps.ListCommand(parseResult.GetValue(fileOrDirectoryArgument)!));
		return listCommand;
	}
}
