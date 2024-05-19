## Release 1.4.0
* Update to use .NET8 ([.NET7 end of life was 14th May 2024](https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-and-net-core))
* Change defaults:
   *  retry delay from 500ms to 50ms
   * number of retries from 5 to 10
* Use [LockChecker](https://www.nuget.org/packages/lockchecker), a fork of [LockCheck](https://github.com/cklutz/LockCheck), instead of git submodules
   * It makes the build faster and it makes it easier to use [ForceOps.Lib](https://www.nuget.org/packages/ForceOps.Lib)
* Update BenchmarkDotNet

## Release 1.3.1
* Fix `forceops delete -h` help command

## Release 1.3.0
* Add `--retry-delay` and `--max-retries` options to `delete` command.

## Release 1.2.1
* Prevent hanging on process kill by @domsleee in https://github.com/domsleee/ForceOps/pull/23
* Disable parallelization on tests

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
