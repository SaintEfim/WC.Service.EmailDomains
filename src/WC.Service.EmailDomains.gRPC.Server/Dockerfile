FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.EmailDomains.gRPC.Server/WC.Service.EmailDomains.gRPC.Server.csproj src/WC.Service.EmailDomains.gRPC.Server/
COPY src/WC.Service.EmailDomains.Domain/WC.Service.EmailDomains.Domain.csproj src/WC.Service.EmailDomains.Domain/
COPY src/WC.Service.EmailDomains.Data.Abstractions/WC.Service.EmailDomains.Data.Abstractions.csproj src/WC.Service.EmailDomains.Data.Abstractions/
COPY src/WC.Service.EmailDomains.Data.PostgreSql/WC.Service.EmailDomains.Data.PostgreSql.csproj src/WC.Service.EmailDomains.Data.PostgreSql/
COPY src/WC.Service.EmailDomains.Data/WC.Service.EmailDomains.Data.csproj src/WC.Service.EmailDomains.Data/
COPY src/WC.Service.EmailDomains.Domain.Abstractions/WC.Service.EmailDomains.Domain.Abstractions.csproj src/WC.Service.EmailDomains.Domain.Abstractions/

RUN dotnet restore src/WC.Service.EmailDomains.gRPC.Server/WC.Service.EmailDomains.gRPC.Server.csproj

COPY src/ .

WORKDIR /src/WC.Service.EmailDomains.gRPC.Server
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WC.Service.EmailDomains.gRPC.Server.dll"]
