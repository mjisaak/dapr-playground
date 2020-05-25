
dotnet build (Join-path $PSScriptRoot 'MyActorService/MyActorService.csproj')

dapr run --app-id myapp --app-port 3000 dotnet (Join-Path $PSScriptRoot 'MyActorService/bin/Debug/netcoreapp3.1/MyActorService.dll') --port 3500

dapr list