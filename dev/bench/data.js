window.BENCHMARK_DATA = {
  "lastUpdate": 1689085237205,
  "repoUrl": "https://github.com/domsleee/ForceOps",
  "entries": {
    "ForceOps Benchmarks": [
      {
        "commit": {
          "author": {
            "email": "domslee1@gmail.com",
            "name": "Dom Slee",
            "username": "domsleee"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "aaa0a43c50cbaefd6541fa23e652b1838396cdbe",
          "message": "Add benchmarks (BenchmarkDotNet) (#14)\n\n* Add benchmarks (BenchmarkDotNet)\r\n* Add gh-pages branch (https://domsleee.github.io/ForceOps/)",
          "timestamp": "2023-07-12T00:14:10+10:00",
          "tree_id": "7544fb917bddbebf341dead80d33681e01af1080",
          "url": "https://github.com/domsleee/ForceOps/commit/aaa0a43c50cbaefd6541fa23e652b1838396cdbe"
        },
        "date": 1689085230377,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 123874685.96491228,
            "unit": "ns",
            "range": "± 4972163.070012839"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 101780050,
            "unit": "ns",
            "range": "± 2739496.468513876"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 264985238.46153846,
            "unit": "ns",
            "range": "± 3206602.9853877197"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 190569078.57142857,
            "unit": "ns",
            "range": "± 2548218.3963819393"
          }
        ]
      }
    ]
  }
}