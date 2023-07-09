using BenchmarkDotNet.Running;

namespace ForceOps.Benchmarks;

public class Program
{
	public static void Main(string[] args)
	{
		BenchmarkRunner.Run<FileAndDirectoryDeletionBenchmark>();
	}
}