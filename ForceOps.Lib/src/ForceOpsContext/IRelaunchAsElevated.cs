using System.Diagnostics;

namespace ForceOps.Lib;

public interface IRelaunchAsElevated
{
	int RelaunchAsElevated(List<string> argListOverride, string outputFile);
}
