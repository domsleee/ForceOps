using System.Runtime.Versioning;
using ConsoleAppFramework;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args)
	{
		ConsoleApp.Run(args, (string message) => Console.Write($"Hello, {message}"));
		return 0;
	}
}