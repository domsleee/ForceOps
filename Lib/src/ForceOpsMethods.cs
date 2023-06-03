namespace ForceOps
{
    public static class ForceOpsMethods
    {
        /// Delete a file or a folder, not following symlinks.
        /// If the delete fails, it will attempt to find processes using the file
        public static void DeleteFileOrFile(string fileOrFolder)
        {
            if (!File.Exists(fileOrFolder))
            {
                throw new ForceOpsError($"File to delete {fileOrFolder} does not exist!");
            }
        }

        public static void MoveFileOrFolder(string sourceFileName, string destFileName)
        {
            sourceFileName = CombineWithCWDAndGetAbsolutePath(sourceFileName);
            destFileName = CombineWithCWDAndGetAbsolutePath(destFileName);
            if (!File.Exists(sourceFileName))
            {
                throw new ForceOpsError($"File to move {sourceFileName} does not exist!");
            }

            File.Move(sourceFileName, destFileName);
        }

        public static string CombineWithCWDAndGetAbsolutePath(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return Path.GetFullPath(Path.Combine(currentDirectory, path));
        }
    }
}