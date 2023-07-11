```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |   StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |             **False** | **459.5 μs** |  **9.05 μs** |  **8.47 μs** |
|           System.IO.Directory.Delete |        1 |       10 |             False | 325.0 μs |  6.40 μs | 13.07 μs |
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |              **True** | **622.1 μs** | **12.39 μs** | **24.17 μs** |
|           System.IO.Directory.Delete |        1 |       10 |              True | 445.3 μs |  7.68 μs |  6.42 μs |

