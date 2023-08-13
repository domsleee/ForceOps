namespace ForceOps.Lib;

public static class DirectoryUtils
{
	public static string CombineWithCWDAndGetAbsolutePath(string path)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		return Path.GetFullPath(Path.Combine(currentDirectory, path));
	}

	public static bool IsSymLink(string folder) => IsSymLink(new DirectoryInfo(folder));

	public static bool IsSymLink(DirectoryInfo folder)
	{
		return (folder.Attributes & FileAttributes.ReparsePoint) != 0;
	}

	public static void MarkAsNotReadOnly(FileSystemInfo fileSystemInfo)
	{
		if ((fileSystemInfo.Attributes & FileAttributes.ReadOnly) != 0)
		{
			fileSystemInfo.Attributes &= ~FileAttributes.ReadOnly;
		}
	}
}
