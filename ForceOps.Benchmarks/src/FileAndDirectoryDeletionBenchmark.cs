using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ForceOps.Lib;

namespace ForceOps.Benchmarks;

// [SimpleJob(RuntimeMoniker.NativeAot70)]
[SimpleJob(RuntimeMoniker.Net70)]
public class FileAndDirectoryDeletionBenchmark
{
	readonly List<byte[]> fileDatas = new();
	readonly string tempDirectory = Path.Join(Path.GetTempPath(), Guid.NewGuid().ToString());
	readonly FileAndDirectoryDeleter fileAndDirectoryDeleter = new FileAndDirectoryDeleter(new ForceOpsContext());

	[Params(/*100, */2000)]
	public int NUM_FILES { get; set; }

	[Params(10/*, 5_000*/)]
	public int FILE_SIZE { get; set; }

	[Params(false, true)]
	public bool IsInsideDirectory { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		var rand = new Random(42);
		for (var fileNumber = 0; fileNumber < NUM_FILES; fileNumber++)
		{
			var entry = new byte[FILE_SIZE];
			rand.NextBytes(entry);
			fileDatas.Add(entry);
		}
		Console.WriteLine(tempDirectory);
	}

	[Benchmark]
	public void Deleter()
	{
		fileAndDirectoryDeleter.DeleteFileOrDirectory(tempDirectory);
	}

	[Benchmark]
	public void BuiltIn()
	{
		Directory.Delete(tempDirectory, true);
	}

	[IterationSetup]
	public void IterationSetup()
	{
		Directory.CreateDirectory(tempDirectory);
		for (var fileNumber = 0; fileNumber < NUM_FILES; fileNumber++)
		{
			if (IsInsideDirectory)
			{
				var dirName = Path.Combine(tempDirectory, fileNumber.ToString().PadLeft(8, '0'));
				Directory.CreateDirectory(dirName);
				var fileName = Path.Combine(dirName, "a.txt");
				File.WriteAllBytes(fileName, fileDatas[fileNumber]);
			}
			else
			{
				var fileName = Path.Combine(tempDirectory, fileNumber.ToString().PadLeft(8, '0'));
				File.WriteAllBytes(fileName, fileDatas[fileNumber]);
			}
		}
	}

	[IterationCleanup]
	public void IterationCleanup()
	{
		if (Directory.Exists(tempDirectory))
		{
			throw new Exception("Deletion failed?");
		}
	}
}

