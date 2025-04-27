window.BENCHMARK_DATA = {
  "lastUpdate": 1745760877746,
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
          "id": "fd53c133b302f8590a5facf7ae124174b519468e",
          "message": "chore(release): 1.0.4 (#16)",
          "timestamp": "2023-07-12T00:49:53+10:00",
          "tree_id": "86517aa2cf2cbcfa7f400a2479de3618be5f1d1d",
          "url": "https://github.com/domsleee/ForceOps/commit/fd53c133b302f8590a5facf7ae124174b519468e"
        },
        "date": 1689087261205,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 122741972.22222222,
            "unit": "ns",
            "range": "± 2559764.5026804726"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 121025514.28571428,
            "unit": "ns",
            "range": "± 3867700.415214283"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 222630180,
            "unit": "ns",
            "range": "± 2479955.236404768"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 225033952.94117647,
            "unit": "ns",
            "range": "± 4566484.087500695"
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
          "id": "835be679eee99a6c3c88ddfb92b43c9b1d54bac6",
          "message": "Bugfix/delete nonexisting file (#17)\n\n* Deleting non-existing file now throws an error\r\n* Add --force and --disable-elevate flags\r\n* When re-launching as admin, --force is implied to avoid edge cases with partial deletions",
          "timestamp": "2023-08-17T19:04:53+10:00",
          "tree_id": "c36554be3220f91f5886401d14626fffd0a985d6",
          "url": "https://github.com/domsleee/ForceOps/commit/835be679eee99a6c3c88ddfb92b43c9b1d54bac6"
        },
        "date": 1692263421734,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 110919374.54545455,
            "unit": "ns",
            "range": "± 4673331.996521372"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 112062286.36363636,
            "unit": "ns",
            "range": "± 4140709.6309348587"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 206419325,
            "unit": "ns",
            "range": "± 3982390.5471462742"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207491888.46153846,
            "unit": "ns",
            "range": "± 2517909.086437416"
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
          "id": "92098679095dbfc7809ac1f8adbc8fde9ed985be",
          "message": "chore(release): 1.1.0 (#18)",
          "timestamp": "2023-08-17T19:36:53+10:00",
          "tree_id": "d46bcaf1949dfda84bb8e1d8851d846cdd460d61",
          "url": "https://github.com/domsleee/ForceOps/commit/92098679095dbfc7809ac1f8adbc8fde9ed985be"
        },
        "date": 1692265472621,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 182421755.3846154,
            "unit": "ns",
            "range": "± 8092019.068367431"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 186056030.20833334,
            "unit": "ns",
            "range": "± 11822161.09709682"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 338483325.86206895,
            "unit": "ns",
            "range": "± 9556365.04668318"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 348693210.6060606,
            "unit": "ns",
            "range": "± 16069005.533942843"
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
          "id": "c0ba92085c56c2dc4939223d61f8379aeaa61cf6",
          "message": "Add \"list\" subcommand (#19)\n\n* Add \"list\" command\r\n\r\n* Update LockCheck to grab the process id of processes owned by another user, improved error handling",
          "timestamp": "2023-09-06T21:42:42+10:00",
          "tree_id": "16128966ea54145731361bf5bf916b2c6cb9770b",
          "url": "https://github.com/domsleee/ForceOps/commit/c0ba92085c56c2dc4939223d61f8379aeaa61cf6"
        },
        "date": 1694001087146,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 129254188.8235294,
            "unit": "ns",
            "range": "± 9386803.114391807"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 137571169.23076922,
            "unit": "ns",
            "range": "± 20824893.116266686"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 242176450,
            "unit": "ns",
            "range": "± 16290467.785977695"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 305638247.7777778,
            "unit": "ns",
            "range": "± 107295571.39433427"
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
          "id": "93984dfba9468ceb31c35e8d1b7f076f9a1118cb",
          "message": "Aot (#20)\n\n* Add AOT",
          "timestamp": "2023-09-06T22:07:29+10:00",
          "tree_id": "c20ccd35266e72b51b6aa8bae626086ad15516a8",
          "url": "https://github.com/domsleee/ForceOps/commit/93984dfba9468ceb31c35e8d1b7f076f9a1118cb"
        },
        "date": 1694002697520,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 167951104.3478261,
            "unit": "ns",
            "range": "± 6392478.159314586"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 169506430,
            "unit": "ns",
            "range": "± 5896433.538630549"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 323553080,
            "unit": "ns",
            "range": "± 8576246.257396065"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 319612046.6666667,
            "unit": "ns",
            "range": "± 5496255.6737508215"
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
          "id": "e5620affcec2bafad889d5c60b14a79037482092",
          "message": "Better relaunch logging (#22)\n\n* Improve relaunch logging - it now shows on the main thread\r\n* Fix `installLocal.ps1`",
          "timestamp": "2023-09-07T20:04:27+10:00",
          "tree_id": "e57bb04114d22736077bdd445952c21c39252c08",
          "url": "https://github.com/domsleee/ForceOps/commit/e5620affcec2bafad889d5c60b14a79037482092"
        },
        "date": 1694081405681,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 115155974.02597402,
            "unit": "ns",
            "range": "± 5856096.966396885"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 115471192.3076923,
            "unit": "ns",
            "range": "± 1428707.0847806993"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204894591.66666666,
            "unit": "ns",
            "range": "± 5223883.2458253205"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 210971032,
            "unit": "ns",
            "range": "± 8438507.142090855"
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
          "id": "3b907bc2be8d81e477dbfe1f32a2fa7b345e213a",
          "message": "chore(release): 1.2.0 (#21)\n\n* Add aot, and exe in release\r\n* Add \"list\" subcommand\r\n* Improve kill processes to not crash on a Win32 exception\r\n* Improve relaunch logging - it now shows on the main thread",
          "timestamp": "2023-09-07T20:20:56+10:00",
          "tree_id": "55829d486cac5eb545b862ba33567c68fa2f7035",
          "url": "https://github.com/domsleee/ForceOps/commit/3b907bc2be8d81e477dbfe1f32a2fa7b345e213a"
        },
        "date": 1694082645627,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 123902359.49367088,
            "unit": "ns",
            "range": "± 45210047.33323062"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108463205,
            "unit": "ns",
            "range": "± 3851822.9639503662"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 195658915.3846154,
            "unit": "ns",
            "range": "± 3218726.60142852"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 196522183.33333334,
            "unit": "ns",
            "range": "± 1313501.217657555"
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
          "id": "79071ab20fe190eb4ad430d4a1fda6612e25e7bd",
          "message": "Prevent hanging on process kill (#23)",
          "timestamp": "2023-09-24T20:47:57+10:00",
          "tree_id": "cc97e5ee540f6d675736515443a8edbd4b1c2f05",
          "url": "https://github.com/domsleee/ForceOps/commit/79071ab20fe190eb4ad430d4a1fda6612e25e7bd"
        },
        "date": 1695552937662,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 192846861.25,
            "unit": "ns",
            "range": "± 21329501.55534268"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 188517564.47368422,
            "unit": "ns",
            "range": "± 9572346.279579932"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 352537017.2413793,
            "unit": "ns",
            "range": "± 14677816.43951096"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 350835588.8888889,
            "unit": "ns",
            "range": "± 11692528.266052833"
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
          "id": "df3cf9ecff907255c77c0aca9483376f7b649c52",
          "message": "chore(release): 1.2.1 (#24)\n\n* chore(release): 1.2.1\r\n* Prevent hanging on process kill\r\n* Disable parallelization on tests",
          "timestamp": "2023-09-25T20:56:12+10:00",
          "tree_id": "6b9a06e666ba4b879ba80422a76d233ec35cf5f1",
          "url": "https://github.com/domsleee/ForceOps/commit/df3cf9ecff907255c77c0aca9483376f7b649c52"
        },
        "date": 1695639741513,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 133937865.46391752,
            "unit": "ns",
            "range": "± 21926048.24184268"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 135399457.57575756,
            "unit": "ns",
            "range": "± 23910600.15511475"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 202986593.61702126,
            "unit": "ns",
            "range": "± 7759344.224123365"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204354036,
            "unit": "ns",
            "range": "± 8123685.047421396"
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
            "email": "domslee1@gmail.com",
            "name": "Dom Slee",
            "username": "domsleee"
          },
          "distinct": true,
          "id": "0f6cc4c951f40cb5d0ae68fc30df88f2fee3377f",
          "message": "Fix typo in docs",
          "timestamp": "2023-09-25T21:06:15+10:00",
          "tree_id": "2d95bd3794f18b5c8379f33f319bae959b3625b7",
          "url": "https://github.com/domsleee/ForceOps/commit/0f6cc4c951f40cb5d0ae68fc30df88f2fee3377f"
        },
        "date": 1695640477961,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109798709.85915492,
            "unit": "ns",
            "range": "± 5350434.019595445"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109960001.88679245,
            "unit": "ns",
            "range": "± 4586998.092497238"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199769514.2857143,
            "unit": "ns",
            "range": "± 2976194.236025171"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 387742720.8333333,
            "unit": "ns",
            "range": "± 286383936.4988631"
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
            "email": "domslee1@gmail.com",
            "name": "Dom Slee",
            "username": "domsleee"
          },
          "distinct": true,
          "id": "543f091aed1f919ad22fb19a3451510adb0a03e7",
          "message": "Update README",
          "timestamp": "2023-10-23T15:21:01+11:00",
          "tree_id": "a7e20034211df219e28cb141d9e629805cca37bb",
          "url": "https://github.com/domsleee/ForceOps/commit/543f091aed1f919ad22fb19a3451510adb0a03e7"
        },
        "date": 1698035235574,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 121597527.4509804,
            "unit": "ns",
            "range": "± 4927138.50112125"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 121244060,
            "unit": "ns",
            "range": "± 3549210.7821705746"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 223343107.69230768,
            "unit": "ns",
            "range": "± 2170254.1527286377"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 222381529.4117647,
            "unit": "ns",
            "range": "± 4416355.154106821"
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
            "email": "domslee1@gmail.com",
            "name": "Dom Slee",
            "username": "domsleee"
          },
          "distinct": true,
          "id": "8d6c9e7420bb1b84d4010a2673fcc34a2d0cccdb",
          "message": "chore(release): 1.3.0\n\n* Add --retry-delay and --max-retries options to delete command",
          "timestamp": "2023-12-03T23:07:36+11:00",
          "tree_id": "9942389051bfa2e2150f51ebb0ff6662c5219b6d",
          "url": "https://github.com/domsleee/ForceOps/commit/8d6c9e7420bb1b84d4010a2673fcc34a2d0cccdb"
        },
        "date": 1701605569046,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109092396.10389611,
            "unit": "ns",
            "range": "± 5502507.796317716"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106392957.14285715,
            "unit": "ns",
            "range": "± 1855290.4730959085"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 201422835,
            "unit": "ns",
            "range": "± 4376428.54551216"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199846425,
            "unit": "ns",
            "range": "± 2875357.8364266246"
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
          "id": "2fc01a99755a86af10e10b7e037cc0aa6fb95942",
          "message": "Update changelog (#27)",
          "timestamp": "2023-12-05T09:37:48+11:00",
          "tree_id": "578ef56e4306a5e2c96bd14747b2adf80fc23cb8",
          "url": "https://github.com/domsleee/ForceOps/commit/2fc01a99755a86af10e10b7e037cc0aa6fb95942"
        },
        "date": 1701729753691,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108448968.29268293,
            "unit": "ns",
            "range": "± 3757610.3699318683"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106497269.23076923,
            "unit": "ns",
            "range": "± 1484498.423926757"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199840959.67741936,
            "unit": "ns",
            "range": "± 7496572.631640554"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199649991.3043478,
            "unit": "ns",
            "range": "± 4437884.825711973"
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
          "id": "7eb61378d417f15021c0318490bbb23752fa391e",
          "message": "chore(release): 1.3.1 (#28)\n\n* Fix `forceops delete -h` help command",
          "timestamp": "2023-12-06T19:57:49+11:00",
          "tree_id": "7d22a285e7656632202b29b8b37388aaabda4f06",
          "url": "https://github.com/domsleee/ForceOps/commit/7eb61378d417f15021c0318490bbb23752fa391e"
        },
        "date": 1701853313034,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107004823.07692307,
            "unit": "ns",
            "range": "± 2788412.506830034"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107562475,
            "unit": "ns",
            "range": "± 2911690.8189070155"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199715915.3846154,
            "unit": "ns",
            "range": "± 2498276.9891954716"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 200809850,
            "unit": "ns",
            "range": "± 3518235.4726700494"
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
          "id": "4767db748302c81265624d89202021a74d6bbeae",
          "message": "Use LockChecker instead of submodule (#30)\n\n* Use LockChecker instead of submodule",
          "timestamp": "2024-05-19T14:06:49+10:00",
          "tree_id": "3f6fb6fdc78c20a32a8b701392ffa6c2139d79af",
          "url": "https://github.com/domsleee/ForceOps/commit/4767db748302c81265624d89202021a74d6bbeae"
        },
        "date": 1716091772133,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108143896.15384616,
            "unit": "ns",
            "range": "± 2892071.8116230476"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 110313362.5,
            "unit": "ns",
            "range": "± 2868220.869218332"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204317309.0909091,
            "unit": "ns",
            "range": "± 3925032.794392459"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 205177853.84615386,
            "unit": "ns",
            "range": "± 2213850.196910119"
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
          "id": "4d4811a303d96a5efcd3e53caa273ebd082aa9ab",
          "message": "Update BenchmarkDotNet (#31)",
          "timestamp": "2024-05-19T15:08:22+10:00",
          "tree_id": "ae879027e02b8fbb80cd711b785e5454205bba1b",
          "url": "https://github.com/domsleee/ForceOps/commit/4d4811a303d96a5efcd3e53caa273ebd082aa9ab"
        },
        "date": 1716095518253,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109512801.85185185,
            "unit": "ns",
            "range": "± 4394748.252239546"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 111293429.54545455,
            "unit": "ns",
            "range": "± 4128546.0211364543"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 206613083.7837838,
            "unit": "ns",
            "range": "± 6905722.239101324"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 206026558.33333334,
            "unit": "ns",
            "range": "± 2299341.8071891526"
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
          "id": "faaf5c2b8f44353956e8050ea9e2e48da5086aee",
          "message": "chore(release): 1.4.0 (#32)\n\n* Update to use .NET8 ([.NET7 end of life was 14th May 2024](https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-and-net-core))\r\n* Change defaults:\r\n   *  retry delay from 500ms to 50ms \r\n   * number of retries from 5 to 10\r\n* Use [LockChecker](https://www.nuget.org/packages/lockchecker), a fork of [LockCheck](https://github.com/cklutz/LockCheck), instead of git submodules\r\n   * It makes the build faster and it makes it easier to use [ForceOps.Lib](https://www.nuget.org/packages/ForceOps.Lib)\r\n* Update BenchmarkDotNet",
          "timestamp": "2024-05-19T15:35:20+10:00",
          "tree_id": "deab2360e8d05e09ee368835fcdb350aa32e3fc7",
          "url": "https://github.com/domsleee/ForceOps/commit/faaf5c2b8f44353956e8050ea9e2e48da5086aee"
        },
        "date": 1716097063331,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109359505.26315789,
            "unit": "ns",
            "range": "± 2318112.9026462897"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108492159.375,
            "unit": "ns",
            "range": "± 3165634.0108858133"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207855092.85714287,
            "unit": "ns",
            "range": "± 2993783.1537176366"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 208833300,
            "unit": "ns",
            "range": "± 4240137.907163481"
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
          "id": "e8128e58d96ad9762096dff0d80e3865ea60117c",
          "message": "Update changelog (#33)",
          "timestamp": "2024-05-19T15:58:14+10:00",
          "tree_id": "0a546d16cf21a96349c797a7429514b5a083336b",
          "url": "https://github.com/domsleee/ForceOps/commit/e8128e58d96ad9762096dff0d80e3865ea60117c"
        },
        "date": 1716098484744,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108178578.57142857,
            "unit": "ns",
            "range": "± 973598.7162454177"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106504089.28571428,
            "unit": "ns",
            "range": "± 2847683.8784110914"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 203416716.66666666,
            "unit": "ns",
            "range": "± 1492321.250348739"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207228173.52941176,
            "unit": "ns",
            "range": "± 5744090.679483269"
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
          "id": "97cb7895071ffd511ac06d9d19da02cec52cb0c0",
          "message": "Use ContinuousIntegrationBuild flag for deterministic builds (#34)",
          "timestamp": "2024-05-19T16:39:50+10:00",
          "tree_id": "47c06dbcd3fdddf0271463b62691f8fb0203db84",
          "url": "https://github.com/domsleee/ForceOps/commit/97cb7895071ffd511ac06d9d19da02cec52cb0c0"
        },
        "date": 1716100992918,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 115206255.10204081,
            "unit": "ns",
            "range": "± 4508951.97510192"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 117552163.84615384,
            "unit": "ns",
            "range": "± 5481942.337514738"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 215103775,
            "unit": "ns",
            "range": "± 2462918.744876419"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 215037185.7142857,
            "unit": "ns",
            "range": "± 3689865.876780127"
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
          "id": "d1568e15e7f70285a4b5f497740a6700ac793150",
          "message": "chore(release): 1.4.1 (#35)\n\n* Use `ContinuousIntegrationBuild` flag for deterministic builds",
          "timestamp": "2024-05-19T16:45:29+10:00",
          "tree_id": "cfa8e7e9dfe972b2d3385e616055f0a2415eacff",
          "url": "https://github.com/domsleee/ForceOps/commit/d1568e15e7f70285a4b5f497740a6700ac793150"
        },
        "date": 1716101322817,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 104295625,
            "unit": "ns",
            "range": "± 2695367.75215328"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 104837450,
            "unit": "ns",
            "range": "± 1814408.5405230755"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199660107.69230768,
            "unit": "ns",
            "range": "± 2721124.512789256"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 202112419.23076922,
            "unit": "ns",
            "range": "± 5479932.352923291"
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
          "id": "5193ca369b7e4be8fa2c5f3eac6a18e1d32eae69",
          "message": "Remove ForceOps.Test from release build (#36)",
          "timestamp": "2024-05-19T21:17:09+10:00",
          "tree_id": "cc5f172e5f1d500ca806085551d0d24456bd5b94",
          "url": "https://github.com/domsleee/ForceOps/commit/5193ca369b7e4be8fa2c5f3eac6a18e1d32eae69"
        },
        "date": 1716117615984,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 109439534.48275863,
            "unit": "ns",
            "range": "± 3045937.203915577"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108293368.42105263,
            "unit": "ns",
            "range": "± 2371173.6018390725"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 203136564.2857143,
            "unit": "ns",
            "range": "± 2090207.0606326738"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204288953.84615386,
            "unit": "ns",
            "range": "± 1229276.5227396863"
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
          "id": "02f628787ab8032168fa0625ad35d88238770ffb",
          "message": "Improve test reliability and fix workstation domain trust issue (#37)\n\n* Improve test reliability and fix workstation domain trust issue",
          "timestamp": "2024-05-20T21:25:34+10:00",
          "tree_id": "b2fd4af70fd0521efb7c9b2156d14c90aa49f65c",
          "url": "https://github.com/domsleee/ForceOps/commit/02f628787ab8032168fa0625ad35d88238770ffb"
        },
        "date": 1716204506093,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 105754659.375,
            "unit": "ns",
            "range": "± 3227953.5712233805"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106744500,
            "unit": "ns",
            "range": "± 3206535.9191293437"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 203864192.85714287,
            "unit": "ns",
            "range": "± 2570114.8913152576"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 203025626.66666666,
            "unit": "ns",
            "range": "± 3756924.577072252"
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
          "id": "87bbfec4712301c7ecc573ec1b9402943ae00601",
          "message": "chore(release): 1.4.2 (#38)",
          "timestamp": "2024-05-20T21:29:55+10:00",
          "tree_id": "63d0d73e55c4b11436548643475c616ff4290c62",
          "url": "https://github.com/domsleee/ForceOps/commit/87bbfec4712301c7ecc573ec1b9402943ae00601"
        },
        "date": 1716204765850,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 105929703.44827586,
            "unit": "ns",
            "range": "± 3098144.5770565365"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107811598.18181819,
            "unit": "ns",
            "range": "± 4268077.908297004"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204187340,
            "unit": "ns",
            "range": "± 5071880.412381586"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204346815.3846154,
            "unit": "ns",
            "range": "± 3296125.554052352"
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
          "id": "f827ae95e6d531c4bd2fb80579fb762c97a9e6d7",
          "message": "Include symbols with ForceOps.Lib (#39)",
          "timestamp": "2024-05-20T22:16:36+10:00",
          "tree_id": "1b8345e359fe0edef436bdb7eb43bfbe42734d75",
          "url": "https://github.com/domsleee/ForceOps/commit/f827ae95e6d531c4bd2fb80579fb762c97a9e6d7"
        },
        "date": 1716207552691,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 105056714.28571428,
            "unit": "ns",
            "range": "± 1514022.1682439349"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 104573080.95238096,
            "unit": "ns",
            "range": "± 2409179.3900868087"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 198984028.57142857,
            "unit": "ns",
            "range": "± 3370814.763965388"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 200935435.7142857,
            "unit": "ns",
            "range": "± 2783174.2941654404"
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
          "id": "e5c61d483218aadffbfbad0e1fddb84af66b7e80",
          "message": "chore(release): 1.4.3 (#40)",
          "timestamp": "2024-05-20T22:19:46+10:00",
          "tree_id": "5d60a111c5f9a7cae750ae367f778bdaea276acc",
          "url": "https://github.com/domsleee/ForceOps/commit/e5c61d483218aadffbfbad0e1fddb84af66b7e80"
        },
        "date": 1716207765019,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 103356142.3076923,
            "unit": "ns",
            "range": "± 2757152.3559169634"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 102684107.6923077,
            "unit": "ns",
            "range": "± 2795199.01172322"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 196816721.42857143,
            "unit": "ns",
            "range": "± 2470546.6891665193"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 199799387.5,
            "unit": "ns",
            "range": "± 3659563.79930268"
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
          "id": "dea09dac03d909ba4d5062bd4e9683b2c41172c2",
          "message": "Add ForceOps.Lib example (ForceOps.DeleteExample) and docs to README.md (#41)",
          "timestamp": "2024-05-31T21:18:24+10:00",
          "tree_id": "1aaec347e26113d417e66bf1261ba226f60fc823",
          "url": "https://github.com/domsleee/ForceOps/commit/dea09dac03d909ba4d5062bd4e9683b2c41172c2"
        },
        "date": 1717154460019,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107764467.5,
            "unit": "ns",
            "range": "± 3745676.6364455572"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 112466534.61538461,
            "unit": "ns",
            "range": "± 1807398.0348584692"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 205671907.14285713,
            "unit": "ns",
            "range": "± 2966426.3595896214"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 211933464.2857143,
            "unit": "ns",
            "range": "± 3715827.434224316"
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
          "id": "b3c99bd442aeabebc5bbf59a6c15cb5b48395f2a",
          "message": "Handle RmGetList() error 5: Access is denied. (#42)",
          "timestamp": "2024-05-31T22:53:35+10:00",
          "tree_id": "4549b88a9d0d9740cfab98a76d1b5a67a647f4d3",
          "url": "https://github.com/domsleee/ForceOps/commit/b3c99bd442aeabebc5bbf59a6c15cb5b48395f2a"
        },
        "date": 1717160167223,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106281223.07692307,
            "unit": "ns",
            "range": "± 1565837.5970248035"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108316128.57142857,
            "unit": "ns",
            "range": "± 3019507.069148029"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 202297714.2857143,
            "unit": "ns",
            "range": "± 2356456.158288133"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207394850,
            "unit": "ns",
            "range": "± 4542631.41332955"
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
          "id": "2d84b62640701a58de64db1abe23f3ca87635be1",
          "message": "chore(release): 1.5.0 (#43)",
          "timestamp": "2024-05-31T22:59:12+10:00",
          "tree_id": "84dc81084c7369d4ece64b304e1b045cdfea51fc",
          "url": "https://github.com/domsleee/ForceOps/commit/2d84b62640701a58de64db1abe23f3ca87635be1"
        },
        "date": 1717160545560,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 113470888,
            "unit": "ns",
            "range": "± 4522081.188587794"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 115898259.25925925,
            "unit": "ns",
            "range": "± 4855640.207892009"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 213256120,
            "unit": "ns",
            "range": "± 4803512.907139174"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 214245665.2173913,
            "unit": "ns",
            "range": "± 5331614.729278781"
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
          "id": "6d72480f251a0e650efd78836eb684a2a6ac5997",
          "message": "Update to .net9 (#44)\n\n* Update dependencies and update to .net9.",
          "timestamp": "2025-04-25T14:23:39+10:00",
          "tree_id": "21c0de5bd536c82892989602964046285a191aac",
          "url": "https://github.com/domsleee/ForceOps/commit/6d72480f251a0e650efd78836eb684a2a6ac5997"
        },
        "date": 1745555215886,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 105891274,
            "unit": "ns",
            "range": "± 4167587.4529864155"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107190832.25806452,
            "unit": "ns",
            "range": "± 4850424.295240613"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204507687.5,
            "unit": "ns",
            "range": "± 5014550.704336202"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 204092090.47619048,
            "unit": "ns",
            "range": "± 4838088.35108504"
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
          "id": "7a0743c89a657a97f3ee275eb2052af1763bc573",
          "message": "Refactor CLI (#45)\n\n* Refactor CLI\n* Update README install instructions",
          "timestamp": "2025-04-27T23:22:11+10:00",
          "tree_id": "862d494668582553a22fd5ebd44430c961632c50",
          "url": "https://github.com/domsleee/ForceOps/commit/7a0743c89a657a97f3ee275eb2052af1763bc573"
        },
        "date": 1745760270542,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106052014.28571428,
            "unit": "ns",
            "range": "± 3009496.6637991127"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 107789006.81818181,
            "unit": "ns",
            "range": "± 4003874.7274619183"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 202625540,
            "unit": "ns",
            "range": "± 4030752.8279988905"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207443750,
            "unit": "ns",
            "range": "± 3550111.6876796987"
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
          "id": "011755061660e71faee4641ce021bc748d8525b1",
          "message": "chore(release): 1.5.1 (#46)",
          "timestamp": "2025-04-27T23:30:18+10:00",
          "tree_id": "f00c92b4aa5a7d472babaf6cc38ec0a594998414",
          "url": "https://github.com/domsleee/ForceOps/commit/011755061660e71faee4641ce021bc748d8525b1"
        },
        "date": 1745760867570,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 108179756.06060606,
            "unit": "ns",
            "range": "± 5095206.148260381"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: False)",
            "value": 106783150,
            "unit": "ns",
            "range": "± 2970816.403130815"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.Deleter(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 207292747.1698113,
            "unit": "ns",
            "range": "± 8576371.96476019"
          },
          {
            "name": "ForceOps.Benchmarks.FileAndDirectoryDeleterBenchmark.DirectoryDelete(NumFiles: 1000, FileSize: 10, IsInsideDirectory: True)",
            "value": 205601617.5,
            "unit": "ns",
            "range": "± 7208967.419102815"
          }
        ]
      }
    ]
  }
}