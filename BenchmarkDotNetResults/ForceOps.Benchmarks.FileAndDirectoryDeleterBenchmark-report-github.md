``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```
|                               Method | NumFiles | FileSize | IsInsideDirectory |     Mean |    Error |   StdDev |   Median |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|---------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |             **False** | **192.8 ms** | **33.52 ms** | **93.45 ms** | **142.1 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |             False | 132.0 ms | 11.89 ms | 34.50 ms | 116.5 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |     **1000** |       **10** |              **True** | **282.9 ms** |  **3.63 ms** |  **3.03 ms** | **283.5 ms** |
|           System.IO.Directory.Delete |     1000 |       10 |              True | 202.7 ms |  2.38 ms |  1.86 ms | 203.1 ms |
