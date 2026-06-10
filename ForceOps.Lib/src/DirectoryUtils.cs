using System.Text.RegularExpressions;

namespace ForceOps.Lib;

public static class DirectoryUtils
{
	static readonly Regex ReservedDeviceNamePattern = new(
		@"^(CON|PRN|AUX|NUL|COM[0-9]|LPT[0-9])(\..+)?$",
		RegexOptions.IgnoreCase | RegexOptions.Compiled);

	public static string CombineWithCWDAndGetAbsolutePath(string path)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		string combined = Path.Combine(currentDirectory, path);

		// Path.GetFullPath resolves reserved device names (NUL, CON, etc.) to \\.\NUL.
		// Resolve the parent directory instead and re-append the filename.
		string fileName = Path.GetFileName(combined);
		if (IsReservedDeviceName(fileName))
		{
			string parentDir = Path.GetFullPath(Path.GetDirectoryName(combined)!);
			return Path.Combine(parentDir, fileName);
		}

		return Path.GetFullPath(combined);
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

	public static bool IsReservedDeviceName(string path)
	{
		var fileName = Path.GetFileName(path);
		return ReservedDeviceNamePattern.IsMatch(fileName);
	}

	public static bool TryDeleteReservedDeviceNameFile(string absolutePath)
	{
		if (!IsReservedDeviceName(absolutePath))
			return false;

		var extendedPath = @"\\?\" + absolutePath;
		if (File.Exists(extendedPath))
		{
			File.Delete(extendedPath);
		}

		return true;
	}
}
