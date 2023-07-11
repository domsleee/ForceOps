``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NUM_FILES | FILE_SIZE | IsInsideDirectory |     Mean |   Error |  StdDev |   Median |
|------------------------------------- |---------- |---------- |------------------ |---------:|--------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |      **1000** |        **10** |             **False** | **137.6 ms** | **3.12 ms** | **9.01 ms** | **135.1 ms** |
|           System.IO.Directory.Delete |      1000 |        10 |             False | 111.4 ms | 2.21 ms | 5.75 ms | 111.5 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |      **1000** |        **10** |              **True** | **279.0 ms** | **5.52 ms** | **9.22 ms** | **276.3 ms** |
|           System.IO.Directory.Delete |      1000 |        10 |              True | 198.5 ms | 3.65 ms | 2.85 ms | 199.2 ms |
