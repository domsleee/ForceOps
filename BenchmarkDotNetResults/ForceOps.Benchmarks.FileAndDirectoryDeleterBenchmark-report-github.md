```


BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  Job-DSOHBH : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **106.1 ms** | **2.10 ms** | **3.01 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 107.8 ms | 2.13 ms | 4.00 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **202.6 ms** | **3.50 ms** | **4.03 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 207.4 ms | 4.00 ms | 3.55 ms |

