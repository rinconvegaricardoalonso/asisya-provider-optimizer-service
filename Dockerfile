# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution
#COPY ProviderOptimizerService.sln .
COPY ProviderOptimizerService.Api/ProviderOptimizerService.Api.csproj ProviderOptimizerService.Api/
COPY ProviderOptimizerService.Application/ProviderOptimizerService.Application.csproj ProviderOptimizerService.Application/
COPY ProviderOptimizerService.Domain/ProviderOptimizerService.Domain.csproj ProviderOptimizerService.Domain/
COPY ProviderOptimizerService.Infrastructure/ProviderOptimizerService.Infrastructure.csproj ProviderOptimizerService.Infrastructure/

# Restore
RUN dotnet restore ProviderOptimizerService.Api/ProviderOptimizerService.Api.csproj

# Copy the rest of the solution
COPY . .

# Build
RUN dotnet publish ProviderOptimizerService.Api \
    -c Release \
    -o /app/publish \
    --no-restore

# =========================
# Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ProviderOptimizerService.Api.dll"]
