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

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **115.2 ms** | **2.28 ms** | **5.86 ms** | **114.9 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 115.5 ms | 1.71 ms | 1.43 ms | 115.3 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **204.9 ms** | **4.02 ms** | **5.22 ms** | **204.9 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 211.0 ms | 4.18 ms | 8.44 ms | 207.3 ms |

