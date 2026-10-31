FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]

COPY ["services/NotificationService/Notification.Worker/Notification.Worker.csproj", "services/NotificationService/Notification.Worker/"]

RUN dotnet restore "services/NotificationService/Notification.Worker/Notification.Worker.csproj"

COPY building-blocks/ building-blocks/
COPY services/NotificationService/ services/NotificationService/

WORKDIR "/src/services/NotificationService/Notification.Worker"
RUN dotnet build "Notification.Worker.csproj" -c Release -o /app/build
RUN dotnet publish "Notification.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Notification.Worker.dll"]

