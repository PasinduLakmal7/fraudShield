FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["building-blocks/FraudShield.Contracts/FraudShield.Contracts.csproj", "building-blocks/FraudShield.Contracts/"]
COPY ["building-blocks/FraudShield.Observability/FraudShield.Observability.csproj", "building-blocks/FraudShield.Observability/"]
COPY ["building-blocks/FraudShield.ServiceDefaults/FraudShield.ServiceDefaults.csproj", "building-blocks/FraudShield.ServiceDefaults/"]

COPY ["services/CustomerService/Customer.Domain/Customer.Domain.csproj", "services/CustomerService/Customer.Domain/"]
COPY ["services/CustomerService/Customer.Application/Customer.Application.csproj", "services/CustomerService/Customer.Application/"]
COPY ["services/CustomerService/Customer.Infrastructure/Customer.Infrastructure.csproj", "services/CustomerService/Customer.Infrastructure/"]
COPY ["services/CustomerService/Customer.API/Customer.API.csproj", "services/CustomerService/Customer.API/"]

RUN dotnet restore "services/CustomerService/Customer.API/Customer.API.csproj"

COPY building-blocks/ building-blocks/
COPY services/CustomerService/ services/CustomerService/

WORKDIR "/src/services/CustomerService/Customer.API"
RUN dotnet build "Customer.API.csproj" -c Release -o /app/build
RUN dotnet publish "Customer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]

