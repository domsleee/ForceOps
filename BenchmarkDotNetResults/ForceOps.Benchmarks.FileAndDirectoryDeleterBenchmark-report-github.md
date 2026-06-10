```


BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.32860) (Hyper-V)
Unknown processor
.NET SDK 10.0.301
  [Host]     : .NET 10.0.9 (10.0.926.27113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  Job-NAVFVV : .NET 10.0.9 (10.0.926.27113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

InvocationCount=1  UnrollFactor=1  

```

| Method                               | NumFiles | FileSize | IsInsideDirectory | Mean     | Error    | StdDev   | Median   |
|------------------------------------- |--------- |--------- |------------------ |---------:|---------:|---------:|---------:|
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **False**             | **168.3 ms** | **11.69 ms** | **33.37 ms** | **157.3 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | False             | 192.1 ms | 23.29 ms | 65.70 ms | 164.9 ms |
| **ForceOps.Lib.FileAndDirectoryDeleter** | **1000**     | **10**       | **True**              | **304.3 ms** | **20.63 ms** | **56.13 ms** | **282.9 ms** |
| System.IO.Directory.Delete           | 1000     | 10       | True              | 332.4 ms | 24.94 ms | 68.70 ms | 307.0 ms |

