```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.2113), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100
  [Host]   : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  .NET 7.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **107.0 ms** | **2.04 ms** | **2.79 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 107.6 ms | 2.03 ms | 2.91 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **199.7 ms** | **2.99 ms** | **2.50 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 200.8 ms | 3.97 ms | 3.52 ms |

