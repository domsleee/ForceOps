``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```
|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |             **False** | **392.5 μs** |  **6.82 μs** | **7.30 μs** |
|           System.IO.Directory.Delete |        1 |       10 |             False | 284.9 μs |  4.32 μs | 3.83 μs |
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |              **True** | **557.5 μs** | **10.10 μs** | **8.44 μs** |
|           System.IO.Directory.Delete |        1 |       10 |              True | 383.3 μs |  7.66 μs | 9.40 μs |

