window.BENCHMARK_DATA = {
  "lastUpdate": 1688991813752,
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
          "id": "a0778d615bd53646d7b0a5aaca2d603306e75941",
          "message": "Add benchmark",
          "timestamp": "2023-07-04T14:19:23Z",
          "url": "https://github.com/domsleee/ForceOps/pull/14/commits/a0778d615bd53646d7b0a5aaca2d603306e75941"
        },
        "date": 1688991806384,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.Deleter(NUM_FILES: 1000, FILE_SIZE: 10, IsInsideDirectory: False)",
            "value": 136588185.45454547,
            "unit": "ns",
            "range": "± 5777585.290215147"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.BuiltIn(NUM_FILES: 1000, FILE_SIZE: 10, IsInsideDirectory: False)",
            "value": 113641236.90476191,
            "unit": "ns",
            "range": "± 5956885.68913664"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.Deleter(NUM_FILES: 1000, FILE_SIZE: 10, IsInsideDirectory: True)",
            "value": 285864692.85714287,
            "unit": "ns",
            "range": "± 4885202.826663123"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeletionBenchmark.BuiltIn(NUM_FILES: 1000, FILE_SIZE: 10, IsInsideDirectory: True)",
            "value": 218069579.78723404,
            "unit": "ns",
            "range": "± 14533836.599737408"
          }
        ]
      }
    ]
  }
}