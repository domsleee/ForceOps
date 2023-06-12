using System.Security.Principal;

namespace ForceOpsLib;

public class ElevateUtils
{
	public static bool IsProcessElevated()
	{
		using var identity = WindowsIdentity.GetCurrent();
		var principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
}