``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.20348.1787), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.305
  [Host]   : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.8 (7.0.823.31807), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  InvocationCount=1  
UnrollFactor=1  

```

|                               Method | NUM_FILES | FILE_SIZE | IsInsideDirectory(hmm) |     Mean |   Error |   StdDev |
|------------------------------------- |---------- |---------- |------------------ |---------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** |      **1000** |        **10** |             **False** | **150.8 ms** | **3.00 ms** |  **6.89 ms** |
|           System.IO.Directory.Delete |      1000 |        10 |             False | 126.2 ms | 2.52 ms |  6.94 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** |      **1000** |        **10** |              **True** | **329.5 ms** | **6.54 ms** | **11.45 ms** |
|           System.IO.Directory.Delete |      1000 |        10 |              True | 234.8 ms | 4.67 ms | 10.92 ms |
