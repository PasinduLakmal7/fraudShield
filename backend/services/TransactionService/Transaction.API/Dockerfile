FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]

COPY ["services/TransactionService/Transaction.Domain/Transaction.Domain.csproj", "services/TransactionService/Transaction.Domain/"]
COPY ["services/TransactionService/Transaction.Application/Transaction.Application.csproj", "services/TransactionService/Transaction.Application/"]
COPY ["services/TransactionService/Transaction.Infrastructure/Transaction.Infrastructure.csproj", "services/TransactionService/Transaction.Infrastructure/"]
COPY ["services/TransactionService/Transaction.API/Transaction.API.csproj", "services/TransactionService/Transaction.API/"]

RUN dotnet restore "services/TransactionService/Transaction.API/Transaction.API.csproj"

COPY building-blocks/ building-blocks/
COPY services/TransactionService/ services/TransactionService/

WORKDIR "/src/services/TransactionService/Transaction.API"
RUN dotnet build "Transaction.API.csproj" -c Release -o /app/build
RUN dotnet publish "Transaction.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]

