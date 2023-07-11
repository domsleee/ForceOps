window.BENCHMARK_DATA = {
  "lastUpdate": 1689084044209,
  "repoUrl": "https://github.com/domsleee/ForceOps",
  "entries": {
    "ForceOps Benchmarks": [
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
          "id": "3c16b65a01d9b4c115753fce3caefbcbd7eba401",
          "message": "Add benchmark",
          "timestamp": "2023-07-04T14:19:23Z",
          "url": "https://github.com/domsleee/ForceOps/pull/14/commits/3c16b65a01d9b4c115753fce3caefbcbd7eba401"
        },
        "date": 1689071958694,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 130324178.57142857,
            "unit": "ns",
            "range": "± 3717312.9002065896"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109807310,
            "unit": "ns",
            "range": "± 1853004.8637707066"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 283328921.4285714,
            "unit": "ns",
            "range": "± 3081673.7531184806"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204790030.76923078,
            "unit": "ns",
            "range": "± 3261269.20446233"
          }
        ]
      },
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
          "id": "95cfdf65874cb27dd18c978c9b58f9ca462e78b7",
          "message": "Add benchmark",
          "timestamp": "2023-07-04T14:19:23Z",
          "url": "https://github.com/domsleee/ForceOps/pull/14/commits/95cfdf65874cb27dd18c978c9b58f9ca462e78b7"
        },
        "date": 1689072493673,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 192801902.2222222,
            "unit": "ns",
            "range": "± 93452778.95329292"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 132009326.80412371,
            "unit": "ns",
            "range": "± 34504247.01926354"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 282945215.38461536,
            "unit": "ns",
            "range": "± 3033574.794925989"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 202707041.66666666,
            "unit": "ns",
            "range": "± 1859675.0387968975"
          }
        ]
      },
    ]
  }
}