```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.2461), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.300
  [Host]   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **108.1 ms** | **2.11 ms** | **2.89 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 110.3 ms | 2.21 ms | 2.87 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **204.3 ms** | **3.20 ms** | **3.93 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 205.2 ms | 2.65 ms | 2.21 ms |

