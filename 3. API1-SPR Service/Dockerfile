
FROM mcr.microsoft.com/dotnet/aspnet:6.0.35-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

COPY /publish .
ENTRYPOINT ["dotnet", "api.dll"]