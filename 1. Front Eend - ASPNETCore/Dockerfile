
# FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-bookworm-slim AS base
FROM mcr.microsoft.com/dotnet/aspnet:6.0.35-bullseye-slim AS base

WORKDIR /app
EXPOSE 4002

COPY ./publish .
ENTRYPOINT ["dotnet", "API.dll"]