```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.2031), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.402
  [Host]   : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **121.6 ms** | **2.41 ms** | **4.93 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 121.2 ms | 2.37 ms | 3.55 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **223.3 ms** | **2.60 ms** | **2.17 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 222.4 ms | 4.30 ms | 4.42 ms |

