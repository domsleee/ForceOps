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
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **103.4 ms** | **2.01 ms** | **2.76 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 102.7 ms | 2.04 ms | 2.80 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **196.8 ms** | **2.79 ms** | **2.47 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 199.8 ms | 3.73 ms | 3.66 ms |

