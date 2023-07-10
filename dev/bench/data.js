window.BENCHMARK_DATA = {
  "lastUpdate": 1688987861101,
  "repoUrl": "https://github.com/domsleee/ForceOps",
  "entries": {
    "Benchmark.Net Benchmark": [
      {
        "commit": {
          "author": {
            "name": "domsleee",
            "username": "domsleee"
          },
          "committer": {
            "name": "domsleee",
            "username": "domsleee"
          },
          "id": "6e08d587a3d8bf089bc248f4a838285647d8cae0",
          "message": "Add benchmark",
          "timestamp": "2023-07-04T14:19:23Z",
          "url": "https://github.com/domsleee/ForceOps/pull/14/commits/6e08d587a3d8bf089bc248f4a838285647d8cae0"
        },
        "date": 1688987853590,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.Deleter(NUM_FILES: 2, FILE_SIZE: 10, IsInsideDirectory: False)",
            "value": 491471.4285714286,
            "unit": "ns",
            "range": "± 8211.570502034925"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.BuiltIn(NUM_FILES: 2, FILE_SIZE: 10, IsInsideDirectory: False)",
            "value": 361575,
            "unit": "ns",
            "range": "± 6911.00571552361"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.Deleter(NUM_FILES: 2, FILE_SIZE: 10, IsInsideDirectory: True)",
            "value": 792807.1428571428,
            "unit": "ns",
            "range": "± 4343.42372677703"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.BuiltIn(NUM_FILES: 2, FILE_SIZE: 10, IsInsideDirectory: True)",
            "value": 546950,
            "unit": "ns",
            "range": "± 5589.424538059949"
          }
        ]
      }
    ]
  }
}