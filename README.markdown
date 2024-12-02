# dotnet issue reproduction

```
docker run --rm -p "52126:80" nginx
curl 'http://127.0.0.1:52126'
```

To run dotnet

```
brew tap isen-ng/dotnet-sdk-versions
brew install --cask dotnet-sdk8
dotnet run
```
