using Serilog;

namespace ForceOps.Lib;

public class ForceOpsLoggerFactory
{
	static readonly ILogger logger = new LoggerConfiguration()
		   .WriteTo.Console()
		   .CreateLogger();

	public static ILogger CreateLogger<T>()
	{
		return logger;
	}
}
