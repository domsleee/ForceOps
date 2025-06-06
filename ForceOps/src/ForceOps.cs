﻿using ForceOps.Lib;
using Serilog;

namespace ForceOps;

internal class ForceOps
{
	internal readonly string[] args;
	internal readonly ForceOpsContext forceOpsContext = new();
	readonly ILogger logger;
	internal Exception? caughtException = null;
	internal List<string>? extraRelaunchArgs = null;

	public ForceOps(string[] args, ForceOpsContext? forceOpsContext = null, ILogger? logger = null)
	{
		this.args = args;
		this.forceOpsContext = forceOpsContext ?? new ForceOpsContext();
		this.logger = logger ?? this.forceOpsContext.loggerFactory.CreateLogger<ForceOps>();
	}

	public void DeleteCommand(string[] filesOrDirectoriesToDelete, bool force, bool disableElevate, int retryDelay, int maxRetries)
	{
		RelaunchHelpers.RunWithRelaunchAsElevated(() =>
		{
			forceOpsContext.maxRetries = maxRetries;
			forceOpsContext.retryDelay = TimeSpan.FromMilliseconds(retryDelay);
			var deleter = new FileAndDirectoryDeleter(forceOpsContext);
			filesOrDirectoriesToDelete = filesOrDirectoriesToDelete.Select(file => DirectoryUtils.CombineWithCWDAndGetAbsolutePath(file)).ToArray();
			foreach (var file in filesOrDirectoriesToDelete)
			{
				deleter.DeleteFileOrDirectory(file, force);
			}
		}, BuildArgsForRelaunch, forceOpsContext, logger, disableElevate);
	}

	public void ListCommand(string fileOrDirectory)
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
}
