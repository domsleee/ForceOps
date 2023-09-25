window.BENCHMARK_DATA = {
  "lastUpdate": 1695640488994,
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
      }
    ]
  }
}