---
layout: default
---

# ForceOps Benchmarks

The goal is to be competitive with the existing C# implementations.

For example, with [System.IO.Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-7.0).

{% include_relative BenchmarkDotNetResults/ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark-report-github.md %}

## Historical data

<iframe src="dev/bench/index.html" width="100%" frameBorder="0"></iframe>
