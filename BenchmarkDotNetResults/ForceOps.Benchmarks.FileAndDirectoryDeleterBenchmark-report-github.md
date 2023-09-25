```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1970), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.401
  [Host]   : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |   StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|---------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **133.9 ms** | **7.56 ms** | **21.93 ms** | **140.7 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 135.4 ms | 8.15 ms | 23.91 ms | 136.7 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **203.0 ms** | **3.98 ms** |  **7.76 ms** | **204.3 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 204.4 ms | 4.02 ms |  8.12 ms | 206.7 ms |

