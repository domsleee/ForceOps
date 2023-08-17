namespace ForceOps.Lib;

class EnvironmentExit : IEnvironmentExit
{
	public void Exit(int exitCode, string message)
	{
		WriteErrorLine(message);
		Environment.Exit(exitCode);
	}

	static void WriteErrorLine(string message)
	{
		var currentColor = Console.ForegroundColor;
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ForegroundColor = currentColor;
	}
}
