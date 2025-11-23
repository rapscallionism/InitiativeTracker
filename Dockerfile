# Build Frontend (Blazor WASM)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-frontend
WORKDIR /src
COPY Frontend/ ./Frontend/
COPY Core/ ./Core/
COPY Backend/ ./Backend/
RUN dotnet publish Frontend/Frontend.csproj -c Release -o /frontend-publish

# Build Backend (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /src
COPY Backend/ ./Backend/
COPY Frontend/ ./Frontend/
COPY Core/ ./Core/
RUN dotnet publish Backend/Backend.csproj -c Release -o /backend-publish

# Combine: Copy Frontend static files into Backend wwwroot
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS combine
WORKDIR /app
COPY --from=build-backend /backend-publish ./
COPY --from=build-frontend /frontend-publish/wwwroot ./wwwroot

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=combine /app ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Backend.dll"]