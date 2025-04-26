using System.Runtime.Versioning;
using Spectre.Console;
using Spectre.Console.Cli;

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
		var app = new CommandApp();
		app.Configure(config =>
		{
			config.SetApplicationName("forceops");
			config.AddCommand<ListCommand>("list")
				.WithDescription("Uses LockCheck to output processes using a file or directory.")
				.WithData(_forceOps);

			config.AddCommand<DeleteCommand>("delete")
				.WithDescription("Delete files or a directories recursively.")
				.WithData(_forceOps);
		});

		app.Configure(config =>
		{
			config.SetExceptionHandler((ex, resolver) =>
			{
				_forceOps.caughtException = ex;
				AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
				if (ex is FileNotFoundException)
				{
					_forceOps.forceOpsContext.environmentExit.Exit((int)ExitCode.FileNotFound, ex.Message);
					return (int)ExitCode.FileNotFound;
				}
				return 1;
			});
		});

		return app.Run(_forceOps.args);
	}
}

class ListCommand : Command<ListCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[fileOrDirectory]")]
		public string FileOrDirectory { get; set; }
	}

	public override int Execute(CommandContext context, Settings settings)
	{
		var forceOps = context.Data as ForceOps;
		forceOps!.ListCommand(settings.FileOrDirectory!);
		return 0;
	}
}

class DeleteCommand : Command<DeleteCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[fileOrDirectory]")]
		public string[] FileOrDirectories { get; set; }

		[CommandOption("-f|--force")]
		public bool Force { get; set; }

		[CommandOption("-d|--disable-elevate")]
		public bool disableElevate { get; set; }

		[CommandOption("-r|--retry-delay")]
		public int retryDelay { get; set; } = 50;

		[CommandOption("-m|--max-retries")]
		public int maxRetries { get; set; } = 10;
	}

	public override int Execute(CommandContext context, Settings s)
	{
		var forceOps = context.Data as ForceOps;
		forceOps.DeleteCommand(s.FileOrDirectories, s.Force, s.disableElevate, s.retryDelay, s.maxRetries);
		return 0;
	}
}
