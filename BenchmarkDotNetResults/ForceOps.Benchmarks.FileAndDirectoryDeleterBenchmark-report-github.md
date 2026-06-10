```


BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.32860/24H2/2024Update/HudsonValley) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK 10.0.301
  [Host]     : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3
  Job-CNUJVU : .NET 10.0.9 (10.0.9, 10.0.926.27113), X64 RyuJIT x86-64-v3

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev   |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **183.9 ms** | **3.58 ms** |  **8.64 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 190.2 ms | 5.73 ms | 15.98 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **355.7 ms** | **7.07 ms** |  **9.68 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 358.3 ms | 7.14 ms |  7.64 ms |

