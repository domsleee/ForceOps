---
layout: default
title: ForceOps Benchmarks
---

<style>
    div.container-lg { max-width: 1250px!important; }
</style>

The goal is to be competitive with the existing C# implementations.

For example, with [System.IO.Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete?view=net-7.0).

## Latest benchmark

{% include_relative BenchmarkDotNetResults/ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark-report-github.md %}

## Historical benchmarks

<div class="iframe-container">
<iframe src="dev/bench/index.html" id="myiframe" style="height:400px;width:100%;border:none;overflow:hidden;"></iframe>
</div>

<script>
    const iframe = document.getElementById("myiframe");
    iframe.onload = () => {
        iframe.style.height = iframe.contentWindow.document.body.scrollHeight + 25 + "px";
        const otherhead = iframe.getElementsByTagName("head")[0];
        const link = iframe.createElement("link");
        link.setAttribute("rel", "stylesheet");
        link.setAttribute("type", "text/css");
        link.setAttribute("href", "../../iframe.css");
        otherhead.appendChild(link);
    }

</script>