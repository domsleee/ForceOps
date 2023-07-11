```
 ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |   Error |  StdDev |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **123.9 ms** | **2.29 ms** | **4.97 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 101.8 ms | 2.00 ms | 2.74 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **265.0 ms** | **3.84 ms** | **3.21 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 190.6 ms | 2.87 ms | 2.55 ms |

