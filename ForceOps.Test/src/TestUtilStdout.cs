using System.Reactive.Disposables;
using System.Text;

namespace ForceOps.Test;

public static class TestUtilStdout
{
	public static string GetStdoutString(StringBuilder stdoutStringBuilder)
	{
		Console.Out.Flush();
		return stdoutStringBuilder.ToString();
	}

	public static IDisposable RedirectStdout(StringBuilder stringBuilder)
	{
		var originalConsoleOut = Console.Out;
		Console.Out.Flush();
		Console.SetOut(new StringWriter(stringBuilder));

		return Disposable.Create(() =>
		{
			Console.SetOut(originalConsoleOut);
			Console.Out.Flush();
		});
	}
}
