```


BenchmarkDotNet v0.13.12, Windows 10 (10.0.20348.2461) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.301
  [Host]   : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  InvocationCount=1  
UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **107.8 ms** | **2.11 ms** | **3.75 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 112.5 ms | 2.16 ms | 1.81 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **205.7 ms** | **3.35 ms** | **2.97 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 211.9 ms | 4.19 ms | 3.72 ms |

