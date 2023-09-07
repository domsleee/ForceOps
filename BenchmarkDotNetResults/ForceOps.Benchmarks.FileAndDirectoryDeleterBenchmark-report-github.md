```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1906), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]   : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |   StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|---------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **123.9 ms** | **17.39 ms** | **45.21 ms** | **109.1 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 108.5 ms |  2.17 ms |  3.85 ms | 109.8 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **195.7 ms** |  **3.85 ms** |  **3.22 ms** | **195.5 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 196.5 ms |  1.68 ms |  1.31 ms | 196.4 ms |

