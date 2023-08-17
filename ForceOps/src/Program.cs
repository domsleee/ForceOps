using System.Runtime.Versioning;

namespace ForceOps;

[SupportedOSPlatform("windows")]
public class Program
{
	public static int Main(string[] args)
	{
		return new ForceOps(args).Run();
	}
}