```


BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  Job-KYHFNN : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **108.2 ms** | **2.16 ms** | **5.10 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 106.8 ms | 2.07 ms | 2.97 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **207.3 ms** | **4.11 ms** | **8.58 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 205.6 ms | 4.06 ms | 7.21 ms |

