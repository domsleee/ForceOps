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

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **109.1 ms** | **2.15 ms** | **5.50 ms** | **107.1 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 106.4 ms | 2.09 ms | 1.86 ms | 106.8 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **201.4 ms** | **3.80 ms** | **4.38 ms** | **199.9 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 199.8 ms | 3.68 ms | 2.88 ms | 199.2 ms |

