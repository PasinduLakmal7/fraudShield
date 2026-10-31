FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]

COPY ["services/FraudDetectionService/Fraud.Domain/Fraud.Domain.csproj", "services/FraudDetectionService/Fraud.Domain/"]
COPY ["services/FraudDetectionService/Fraud.Application/Fraud.Application.csproj", "services/FraudDetectionService/Fraud.Application/"]
COPY ["services/FraudDetectionService/Fraud.Infrastructure/Fraud.Infrastructure.csproj", "services/FraudDetectionService/Fraud.Infrastructure/"]
COPY ["services/FraudDetectionService/Fraud.API/Fraud.API.csproj", "services/FraudDetectionService/Fraud.API/"]

RUN dotnet restore "services/FraudDetectionService/Fraud.API/Fraud.API.csproj"

COPY building-blocks/ building-blocks/
COPY services/FraudDetectionService/ services/FraudDetectionService/

WORKDIR "/src/services/FraudDetectionService/Fraud.API"
RUN dotnet build "Fraud.API.csproj" -c Release -o /app/build
RUN dotnet publish "Fraud.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Fraud.API.dll"]

