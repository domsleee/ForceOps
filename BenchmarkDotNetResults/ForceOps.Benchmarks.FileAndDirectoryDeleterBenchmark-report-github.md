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
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **106.3 ms** | **1.88 ms** | **1.57 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 108.3 ms | 2.11 ms | 3.02 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **202.3 ms** | **2.66 ms** | **2.36 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 207.4 ms | 3.94 ms | 4.54 ms |

