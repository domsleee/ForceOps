```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |   StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |             **False** | **302.4 μs** | **5.96 μs** | **12.96 μs** |
|           System.IO.Directory.Delete |        1 |       10 |             False | 215.3 μs | 3.99 μs |  5.97 μs |
| **ForceOps.Lib.FileAndDirectoryDeleter** |        **1** |       **10** |              **True** | **411.0 μs** | **7.99 μs** | **11.21 μs** |
|           System.IO.Directory.Delete |        1 |       10 |              True | 284.8 μs | 4.80 μs |  4.01 μs |

