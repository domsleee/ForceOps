---
layout: default
---

The goal is to be competitive with the existing C# implementations.

For example, with [System.IO.Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-7.0).

## Latest benchmark (from [Benchmark Github Action](https://github.com/domsleee/ForceOps/actions/workflows/benchmark.yaml))

{% include_relative BenchmarkDotNetResults/ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark-report-github.md %}

## Historical benchmarks

See [Historical Benchmarks](./dev/bench/index.html).

{% include_relative assets/html/benchmarks.html %}
<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/chart.js@2.9.2/dist/Chart.min.js"></script>
<script type="text/javascript" src="./dev/bench/data.js"></script>
<script type="text/javascript" id="main-script" src="./assets/js/mainScript.js"></script>

