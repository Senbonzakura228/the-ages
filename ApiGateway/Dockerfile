FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ApiGateway.sln ./
COPY API/API.csproj API/

RUN dotnet restore ApiGateway.sln

COPY . .
WORKDIR /src/API
RUN dotnet publish -c Development -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]