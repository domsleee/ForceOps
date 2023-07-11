using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ForceOps.Lib;

namespace ForceOps.Benchmarks;

// [SimpleJob(RuntimeMoniker.NativeAot70)]
[SimpleJob(RuntimeMoniker.Net70)]
public class FileAndDirectoryDeleterBenchmark
{
	readonly List<byte[]> fileDatas = new();
	readonly string tempDirectory = Path.Join(Path.GetTempPath(), Guid.NewGuid().ToString());
	readonly FileAndDirectoryDeleter fileAndDirectoryDeleter = new(new ForceOpsContext());

	[Params(/*100, */1)]
	public int NumFiles { get; set; }

	[Params(10/*, 5_000*/)]
	public int FileSize { get; set; }

	[Params(false, true)]
	public bool IsInsideDirectory { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		var rand = new Random(42);
		for (var fileNumber = 0; fileNumber < NumFiles; fileNumber++)
		{
			var entry = new byte[FileSize];
			rand.NextBytes(entry);
			fileDatas.Add(entry);
		}
		Console.WriteLine(tempDirectory);
	}

	[Benchmark(Description = "ForceOps.Lib.FileAndDirectoryDeleter")]
	public void Deleter()
	{
		fileAndDirectoryDeleter.DeleteFileOrDirectory(tempDirectory);
	}

	[Benchmark(Description = "System.IO.Directory.Delete")]
	public void DirectoryDelete()
	{
		Directory.Delete(tempDirectory, true);
	}

	[IterationSetup]
	public void IterationSetup()
	{
		Directory.CreateDirectory(tempDirectory);
		for (var fileNumber = 0; fileNumber < NumFiles; fileNumber++)
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

