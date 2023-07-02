using System.Security.Principal;

namespace ForceOps.Lib;

public class ElevateUtils : IElevateUtils
{
	public bool IsProcessElevated()
	{
		using var identity = WindowsIdentity.GetCurrent();
		var principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
}

public interface IElevateUtils
{
	public bool IsProcessElevated();
}