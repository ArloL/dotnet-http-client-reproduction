# dotnet issue reproduction

To install dotnet use <https://learn.microsoft.com/en-us/dotnet/core/install/macos#install-net-with-a-script> OR

```
brew tap isen-ng/dotnet-sdk-versions
brew install --cask dotnet-sdk8
```

```
docker run --rm -p "52126:80" nginx
curl 'http://127.0.0.1:52126'
dotnet run
```

## Debug Info

```
curl --version
sw_vers
docker info
```
