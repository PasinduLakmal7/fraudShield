FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]

COPY ["services/IdentityService/Identity.Domain/Identity.Domain.csproj", "services/IdentityService/Identity.Domain/"]
COPY ["services/IdentityService/Identity.Application/Identity.Application.csproj", "services/IdentityService/Identity.Application/"]
COPY ["services/IdentityService/Identity.Infrastructure/Identity.Infrastructure.csproj", "services/IdentityService/Identity.Infrastructure/"]
COPY ["services/IdentityService/Identity.API/Identity.API.csproj", "services/IdentityService/Identity.API/"]

RUN dotnet restore "services/IdentityService/Identity.API/Identity.API.csproj"

COPY building-blocks/ building-blocks/
COPY services/IdentityService/ services/IdentityService/

WORKDIR "/src/services/IdentityService/Identity.API"
RUN dotnet build "Identity.API.csproj" -c Release -o /app/build
RUN dotnet publish "Identity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]

