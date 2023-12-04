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
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **108.4 ms** | **2.08 ms** | **3.76 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 106.5 ms | 1.78 ms | 1.48 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **199.8 ms** | **3.29 ms** | **7.50 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 199.6 ms | 3.51 ms | 4.44 ms |

