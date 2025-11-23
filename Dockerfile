# Build Frontend (Blazor WASM)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-frontend
WORKDIR /src

# copy solution projects
COPY Frontend/ ./Frontend/
COPY Core/ ./Core/
COPY Backend/ ./Backend/

# restore & publish frontend
WORKDIR /src/Frontend
RUN dotnet restore
RUN dotnet publish Frontend.csproj -c Release -o /frontend-publish

# Build Backend (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /src

COPY Backend/ ./Backend/
COPY Core/ ./Core/
COPY Frontend/ ./Frontend/

WORKDIR /src/Backend
RUN dotnet restore
RUN dotnet publish Backend.csproj -c Release -o /backend-publish

# Combine: put frontend publish contents into backend publish (preserve manifests)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS combine
WORKDIR /app

# copy backend published app
COPY --from=build-backend /backend-publish/ ./

# copy the entire frontend publish output (not only wwwroot) so StaticWebAssets manifest and boot assets are available
COPY --from=build-frontend /frontend-publish/ ./frontend-publish/

# If needed, copy frontend wwwroot into backend wwwroot (ensures client files are served)
# If your backend expects files in ./wwwroot, copy them there:
RUN mkdir -p wwwroot
COPY --from=build-frontend /frontend-publish/wwwroot/ ./wwwroot/

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# copy combined app
COPY --from=combine /app/ ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# persistent key folder (container filesystem path)
VOLUME /var/dpkeys

ENTRYPOINT ["dotnet", "Backend.dll"]
