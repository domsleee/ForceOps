using Serilog;

namespace ForceOps.Lib;

public static class RelaunchHelpers
{
	public static void RunWithRelaunchAsElevated(Action action, Func<List<string>> buildArgsForRelaunch, ForceOpsContext forceOpsContext, ILogger? logger = null, bool disableElevate = false)
	{
		logger = logger ?? forceOpsContext.loggerFactory.CreateLogger<object>();
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
				throw new AggregateException($"Child process failed with exit code {childProcessExitCode}.");
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
