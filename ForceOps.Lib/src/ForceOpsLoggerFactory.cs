using Serilog;

namespace ForceOps;

public class ForceOpsLoggerFactory
{
	static ILogger logger = new LoggerConfiguration()
		   .WriteTo.Console()
		   .CreateLogger();

	public static ILogger CreateLogger<T>()
	{
		return logger;
	}
}
