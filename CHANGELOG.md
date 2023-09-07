## Release 1.2.0
* Add aot, and exe in release
* Add "list" subcommand
* Improve kill processes to not crash on a Win32 exception
* Improve relaunch logging - it now shows on the main thread

## Release 1.1.0
* Add `--force` and `--disable-elevate` flags.
* Deleting non-existing file now throws an error (unless `--force` is specified).
* When re-launching as admin, `--force` is implied to avoid edge cases with partial deletions.

## Release 1.0.4
* Improve performance by ~30% by reducing calls to win32 api
* Add benchmarks (BenchmarkDotNet)

## Release 1.0.3
* Update LockCheck dep.

## Release 1.0.2

* Update LockCheck dep.

## Release 1.0.1

* Update log messages to closer match MSBuild
* Fix incorrect exception being thrown when relaunching as elevated works
* Prevent killing own process
* Fix deleting of read-only directories

## Release 1.0.0

First release of ForceOps.
