window.BENCHMARK_DATA = {
  "lastUpdate": 1689086528029,
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
      },
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
          "id": "07ee247454cacf4671efb105fbbf934c7e264cad",
          "message": "Improve performance by ~30% by reducing calls to win32 api (#15)",
          "timestamp": "2023-07-12T00:37:34+10:00",
          "tree_id": "417c81d9436f74c5bd8ef3efda72a48a1677d586",
          "url": "https://github.com/domsleee/ForceOps/commit/07ee247454cacf4671efb105fbbf934c7e264cad"
        },
        "date": 1689086520390,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 113045704.05405405,
            "unit": "ns",
            "range": "± 3767077.1966985078"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 113418913.51351352,
            "unit": "ns",
            "range": "± 3817585.1878847126"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 201830266.66666666,
            "unit": "ns",
            "range": "± 3698765.4334608335"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199957711.7647059,
            "unit": "ns",
            "range": "± 3907444.5133428243"
          }
        ]
      }
    ]
  }
}