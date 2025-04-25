# ForceOps

[![main build](https://github.com/domsleee/forceops/actions/workflows/ci.yaml/badge.svg?branch=main)](https://github.com/domsleee/forceops/actions/workflows/ci.yaml)
[![Nuget](https://img.shields.io/nuget/v/ForceOps)](https://www.nuget.org/packages/ForceOps/)

Forcefully perform file operations by terminating processes that are using the file or directory.

Only supports windows, and not planned to support linux.

Uses [LockChecker](https://github.com/domsleee/LockCheck) to find processes locking files, and will elevate itself if it the process is owned by another user.

## Installation

```shell
dotnet tool install -g forceops
```

To update:
```
dotnet tool update -g forceops
```

Alternatively, the executable is available for download in [the latest release]([releases](https://github.com/domsleee/ForceOps/releases/atest)).


## Usage: As a CLI
### Deleting when a process owned by the current user is using it
```shell
❯ forceops rm .\bin\
[14:55:33 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.dll". Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [100724 - myprogram.exe].
[14:55:34 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.dll". Beginning retry 2/10 in 50ms. ForceOps process is not elevated. Found 0 processes to try to kill: [].
```
### Deleting when a process owned by another user is using it (e.g. a windows service)
```shell
❯ forceops rm .\bin\Debug\net6\myprogram.exe
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 1/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 2/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 3/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 4/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 5/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 6/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 7/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 8/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 9/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Could not delete file "C:\Users\user\myprogram\bin\Debug\net6\myprogram.exe". Beginning retry 10/10 in 50ms. ForceOps process is not elevated. Found 1 process to try to kill: [115744 - ].
[15:07:39 WRN] Failed to kill process 115744: Access is denied.
[15:07:39 INF] Exceeded retry count of 10. Failed. ForceOps process is not elevated.
[15:07:39 INF] Unable to perform operation as an unelevated process. Retrying as elevated and logging to "C:\Users\user\AppData\Local\Temp\tmp9C14.tmp".
[15:07:42 INF] Successfully deleted as admin
```

## Usage: As a library

See the [ForceOps.Lib](https://www.nuget.org/packages/ForceOps.Lib) package.

The easier way is to have an exe target using `RelaunchHelpers.RunWithRelaunchAsElevated`, which is shown in [ForceOps.DeleteExample](./ForceOps.DeleteExample/Program.cs):

```csharp
using ForceOps.Lib;

var fileOrDirectories = args.Select(arg => Path.Combine(Environment.CurrentDirectory, arg)).ToArray();
var forceOpsContext = new ForceOpsContext();
var fileAndDirectoryDeleter = new FileAndDirectoryDeleter(forceOpsContext);

RelaunchHelpers.RunWithRelaunchAsElevated(() =>
{
	foreach (var fileOrDirectory in fileOrDirectories)
	{
		fileAndDirectoryDeleter.DeleteFileOrDirectory(fileOrDirectory, true);
	}
}, () => args.ToList(), forceOpsContext);
```

## Context

See [Benchmarks](https://domsleee.github.io/ForceOps/) on github pages.

Refer also to `10.4 Example: file deletion in Windows` from "A Philosophy of Software Design", which explains why this is a windows specific problem. Linux does not prevent the user from deleting a file if it is being used, see [unlink](https://man7.org/linux/man-pages/man2/unlink.2.html#:~:text=unlink()%20deletes%20a%20name,is%20made%20available%20for%20reuse.):

> If the name was the last link to a file but any processes still
       have the file open, the file will remain in existence until the
       last file descriptor referring to it is closed.

Currently, only `delete` is supported.

Operations like `move` and `copy` can have similar issues if they are overriding files or the source file is in use. It would be reasonable to support these operations in a similar way.

For copying, consider using [Microsoft.Build.CopyOnWrite](https://github.com/microsoft/MSBuildSdks/tree/main/src/CopyOnWrite).
