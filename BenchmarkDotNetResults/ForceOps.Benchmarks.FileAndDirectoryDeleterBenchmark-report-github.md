```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1970), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.401
  [Host]   : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |    StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|----------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **109.8 ms** |  **2.18 ms** |   **5.35 ms** | **109.7 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 110.0 ms |  2.20 ms |   4.59 ms | 110.3 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **199.8 ms** |  **3.36 ms** |   **2.98 ms** | **198.7 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 387.7 ms | 99.26 ms | 286.38 ms | 203.7 ms |

