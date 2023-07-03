using Serilog;

namespace ForceOps.Lib;

public class LoggerFactory : ILoggerFactory
{
	readonly ILogger logger = new LoggerConfiguration()
		   .WriteTo.Console()
		   .CreateLogger();

	public ILogger CreateLogger<T>()
	{
		return logger;
	}
}