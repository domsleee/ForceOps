```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1906), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]   : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |    StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|----------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **129.3 ms** |  **3.47 ms** |   **9.39 ms** | **127.5 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 137.6 ms |  7.43 ms |  20.82 ms | 129.5 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **242.2 ms** |  **5.91 ms** |  **16.29 ms** | **237.6 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 305.6 ms | 38.49 ms | 107.30 ms | 248.4 ms |

