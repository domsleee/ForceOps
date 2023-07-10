---
layout: default
---

# ForceOps Benchmarks

The goal is to be competitive with the existing C# implementations.

For example, with [System.IO.Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-7.0).

{% include_relative BenchmarkDotNetResults/ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark-report-github.md %}

## Historical data

<div class="iframe-container">
<iframe src="dev/bench/index.html" onload='javascript:(function(o){o.style.height=o.contentWindow.document.body.scrollHeight+"px";}(this));' style="height:400px;width:100%;border:none;overflow:hidden;"></iframe>
</div>