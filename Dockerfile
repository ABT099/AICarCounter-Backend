# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["CarBackend.presentation/CarBackend.Presentation.csproj", "CarBackend.presentation/"]
COPY ["CarBackend.Core/CarBackend.Core.csproj", "CarBackend.Core/"]
COPY ["CarBackend.Data/CarBackend.Data.csproj", "CarBackend.Data/"]
COPY ["CarBackend.Services/CarBackend.Services.csproj", "CarBackend.Services/"]

# Install dotnet-ef as a local tool
RUN dotnet new tool-manifest
RUN dotnet tool install dotnet-ef

RUN dotnet restore "CarBackend.presentation/CarBackend.Presentation.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/CarBackend.presentation"
RUN dotnet publish -c Release -o /app/publish

# 2. Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CarBackend.Presentation.dll"]
