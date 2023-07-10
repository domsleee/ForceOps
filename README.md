# ForceOps

[![main build](https://github.com/domsleee/forceops/actions/workflows/ci.yaml/badge.svg?branch=main)](https://github.com/domsleee/forceops/actions/workflows/ci.yaml)
[![Nuget](https://img.shields.io/nuget/v/ForceOps)](https://www.nuget.org/packages/ForceOps/)

Forcefully perform file operations by terminating processes that are using the file.

Currently only supports windows.

Uses [LockCheck](https://github.com/cklutz/LockCheck) to find processes locking files, and will elevate itself if it the process is owned by another user.

## Supported operations

Currently, only `delete` is supported.

Operations like `move` and `copy` can have similar issues if they are overriding files or the source file is in use. It would be reasonable to support these operations in a similar way.

## Usage: As a CLI

To install:
```bash
dotnet tool install -g forceops
```

To delete a file:
```bash
forceops delete file.txt
```

## Usage: As a library

See the [ForceOps.Lib](https://www.nuget.org/packages/ForceOps.Lib) package.