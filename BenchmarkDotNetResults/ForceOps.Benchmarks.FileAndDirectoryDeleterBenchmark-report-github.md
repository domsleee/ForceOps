```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1906), VM=Hyper-V
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]   : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **168.0 ms** | **3.32 ms** | **6.39 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 169.5 ms | 3.32 ms | 5.90 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **323.6 ms** | **6.42 ms** | **8.58 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 319.6 ms | 5.88 ms | 5.50 ms |

