```


BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  Job-GLLFQA : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **105.9 ms** | **2.06 ms** | **4.17 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 107.2 ms | 2.13 ms | 4.85 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **204.5 ms** | **3.86 ms** | **5.01 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 204.1 ms | 4.06 ms | 4.84 ms |

