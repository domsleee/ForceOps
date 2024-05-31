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
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **113.5 ms** | **2.24 ms** | **4.52 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 115.9 ms | 2.30 ms | 4.86 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **213.3 ms** | **4.17 ms** | **4.80 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 214.2 ms | 4.22 ms | 5.33 ms |

