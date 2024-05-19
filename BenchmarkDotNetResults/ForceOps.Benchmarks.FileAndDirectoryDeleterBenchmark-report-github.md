```


BenchmarkDotNet v0.13.12, Windows 10 (10.0.20348.2461) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.300
  [Host]   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  InvocationCount=1  
UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  | Median   |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **109.5 ms** | **2.08 ms** | **4.39 ms** | **109.5 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 111.3 ms | 2.20 ms | 4.13 ms | 110.9 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **206.6 ms** | **4.07 ms** | **6.91 ms** | **203.5 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 206.0 ms | 2.95 ms | 2.30 ms | 206.3 ms |

