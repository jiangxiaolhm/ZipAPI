# ZipAPI

## Summary
This project is based on ASP.Net Core 3.0 Web API, Entity Framework Core 3.0 and Microsoft SQL Server database.

Both the ASP.Net Core Web API application and the Microsoft SQL Server database are containerised by Docker.

## Development Environments
- Windows 10
- Visual Studio 2019
- Docker for Windows

## Required Docker Images
- mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim
- mcr.microsoft.com/dotnet/core/sdk:3.0-buster
- mcr.microsoft.com/msssql/server/latest

## How to run the application?
Open solution in the Visual Studio and run the "Docker Compose" project or run the following command in the root directory of the solution.
```
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" up
```

### Entry Point
```
https://localhost:44334/swagger/index.html
```
