
FROM mcr.microsoft.com/dotnet/aspnet:6.0.35-bullseye-slim AS base
WORKDIR /app
EXPOSE 4001

COPY /publish .
ENTRYPOINT ["dotnet", "api.dll"]