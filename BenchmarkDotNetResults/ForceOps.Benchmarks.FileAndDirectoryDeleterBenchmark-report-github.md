```


BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.32860) (Hyper-V)
Unknown processor
.NET SDK 10.0.301
  [Host]     : .NET 10.0.9 (10.0.926.27113), X64 RyuJIT AVX2
  Job-LVHLZU : .NET 10.0.9 (10.0.926.27113), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error   | StdDev  |
|------------------------------------- |--------- |--------- |------------------ |---------:|--------:|--------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **178.5 ms** | **3.55 ms** | **8.98 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 177.1 ms | 3.46 ms | 8.42 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **342.4 ms** | **6.78 ms** | **9.51 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 341.8 ms | 6.53 ms | 8.26 ms |

