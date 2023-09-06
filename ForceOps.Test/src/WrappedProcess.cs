using System.Diagnostics;

namespace ForceOps.Test;

public class WrappedProcess : IDisposable
{
	public readonly Process process;

	public WrappedProcess(Process process)
	{
		this.process = process;
	}

	void IDisposable.Dispose()
	{
		process.Kill();
		process.WaitForExit(1);
	}
}
