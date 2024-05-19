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
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **109.4 ms** | **2.09 ms** | **2.32 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 108.5 ms | 2.03 ms | 3.17 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **207.9 ms** | **3.38 ms** | **2.99 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 208.8 ms | 3.96 ms | 4.24 ms |

