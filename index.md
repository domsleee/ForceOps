---
layout: default
---

The goal is to be competitive with the existing C# implementations.

For example, with [System.IO.Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-7.0).

## Latest benchmark (from [Benchmark Github Action](https://github.com/domsleee/ForceOps/actions/workflows/benchmark.yaml))

{% include_relative BenchmarkDotNetResults/ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark-report-github.md %}

## Historical benchmarks

See [Historical Benchmarks](./dev/bench/index.html).

{% include_relative benchmarks.html %}
