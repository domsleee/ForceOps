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
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **212.6 ms** | **4.25 ms** | **10.82 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 212.4 ms | 4.20 ms | 11.14 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **384.5 ms** | **7.66 ms** | **16.66 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 380.3 ms | 7.57 ms |  9.84 ms |

