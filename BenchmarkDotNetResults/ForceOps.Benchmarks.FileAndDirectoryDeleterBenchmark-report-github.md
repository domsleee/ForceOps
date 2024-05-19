```


BenchmarkDotNet v0.13.12, Windows 10 (10.0.20348.2461) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.300
  [Host]   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  InvocationCount=1  
UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **115.2 ms** | **2.26 ms** | **4.51 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 117.6 ms | 2.35 ms | 5.48 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **215.1 ms** | **3.15 ms** | **2.46 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 215.0 ms | 4.16 ms | 3.69 ms |

