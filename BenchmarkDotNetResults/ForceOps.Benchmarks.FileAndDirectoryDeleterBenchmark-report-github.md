```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1850), VM=Hyper-V
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]   : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |   StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **182.4 ms** | **3.46 ms** |  **8.09 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 186.1 ms | 4.10 ms | 11.82 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **338.5 ms** | **6.52 ms** |  **9.56 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 348.7 ms | 6.82 ms | 16.07 ms |

