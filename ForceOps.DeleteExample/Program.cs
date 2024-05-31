using ForceOps.Lib;

var fileOrDirectories = args.Select(arg => Path.Combine(Environment.CurrentDirectory, arg)).ToArray();
var forceOpsContext = new ForceOpsContext();
var fileAndDirectoryDeleter = new FileAndDirectoryDeleter(forceOpsContext);

RelaunchHelpers.RunWithRelaunchAsElevated(() =>
{
	foreach (var fileOrDirectory in fileOrDirectories)
	{
		fileAndDirectoryDeleter.DeleteFileOrDirectory(fileOrDirectory, true);
	}
}, () => args.ToList(), forceOpsContext);
