
namespace ForceOps;

public static class TeeCommand
{
    const int MAX_COUNT = 100;

    public static void TeeFile(string file)
	{
        WaitForFileToExist(file);
		Console.WriteLine("INBOUND");
		using var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using var reader = new StreamReader(fileStream);
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			Console.WriteLine(line);
		}
	}

    static bool WaitForFileToExist(string file)
	{
        for (int count = 0; count < MAX_COUNT; ++count) {
            if (File.Exists(file))
			{
                return true;
            }
            Thread.Sleep(100);
        }
        return false;
    }
}