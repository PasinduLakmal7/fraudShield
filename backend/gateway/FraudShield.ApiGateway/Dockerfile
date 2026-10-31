FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["gateway/FraudShield.ApiGateway/FraudShield.ApiGateway.csproj", "gateway/FraudShield.ApiGateway/"]

RUN dotnet restore "gateway/FraudShield.ApiGateway/FraudShield.ApiGateway.csproj"

COPY gateway/FraudShield.ApiGateway/ gateway/FraudShield.ApiGateway/
WORKDIR "/src/gateway/FraudShield.ApiGateway"
RUN dotnet build "FraudShield.ApiGateway.csproj" -c Release -o /app/build
RUN dotnet publish "FraudShield.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FraudShield.ApiGateway.dll"]
