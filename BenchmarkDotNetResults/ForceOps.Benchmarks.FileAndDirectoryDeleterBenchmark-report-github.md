```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1850), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.400
  [Host]   : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **110.9 ms** | **2.19 ms** | **4.67 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 112.1 ms | 2.20 ms | 4.14 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **206.4 ms** | **4.05 ms** | **3.98 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 207.5 ms | 3.02 ms | 2.52 ms |

