# Use the .NET 9 SDK instead of 8
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app
COPY . ./
RUN dotnet restore ./SneakerStoreAPI.csproj
RUN dotnet publish ./SneakerStoreAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "SneakerStoreAPI.dll"]
