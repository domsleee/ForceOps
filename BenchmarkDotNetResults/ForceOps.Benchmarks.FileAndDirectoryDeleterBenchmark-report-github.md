```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1970), VM=Hyper-V
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.401
  [Host]   : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |   StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **192.8 ms** | **8.15 ms** | **21.33 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 188.5 ms | 3.76 ms |  9.57 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **352.5 ms** | **6.69 ms** | **14.68 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 350.8 ms | 7.00 ms | 11.69 ms |

