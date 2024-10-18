
FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 4006

COPY ./publish .
ENTRYPOINT ["dotnet", "API.dll"]