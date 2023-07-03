using Serilog;

namespace ForceOps.Lib;

public interface ILoggerFactory
{
	public ILogger CreateLogger<T>();
}