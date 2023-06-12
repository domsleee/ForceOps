pwsh -NoProfile -Command {
    cd ForceOps
    dotnet pack -c release
    if (Get-Command "forceops.exe" -ErrorAction SilentlyContinue) 
    {
        dotnet tool uninstall -g ForceOps
    }
    dotnet tool install -g ForceOps --prerelease --add-source "$(pwd)/nupkg"
}