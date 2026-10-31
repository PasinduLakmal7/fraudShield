FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]

COPY ["services/AlertService/Alert.Domain/Alert.Domain.csproj", "services/AlertService/Alert.Domain/"]
COPY ["services/AlertService/Alert.Application/Alert.Application.csproj", "services/AlertService/Alert.Application/"]
COPY ["services/AlertService/Alert.Infrastructure/Alert.Infrastructure.csproj", "services/AlertService/Alert.Infrastructure/"]
COPY ["services/AlertService/Alert.API/Alert.API.csproj", "services/AlertService/Alert.API/"]

RUN dotnet restore "services/AlertService/Alert.API/Alert.API.csproj"

COPY building-blocks/ building-blocks/
COPY services/AlertService/ services/AlertService/

WORKDIR "/src/services/AlertService/Alert.API"
RUN dotnet build "Alert.API.csproj" -c Release -o /app/build
RUN dotnet publish "Alert.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Alert.API.dll"]

