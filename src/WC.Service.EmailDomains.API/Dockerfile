FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet tool install --global NSwag.ConsoleCore

COPY src/WC.Service.EmailDomains.API/WC.Service.EmailDomains.API.csproj src/WC.Service.EmailDomains.API/
COPY src/WC.Service.EmailDomains.Domain/WC.Service.EmailDomains.Domain.csproj src/WC.Service.EmailDomains.Domain/
COPY src/WC.Service.EmailDomains.Data.Abstractions/WC.Service.EmailDomains.Data.Abstractions.csproj src/WC.Service.EmailDomains.Data.Abstractions/
COPY src/WC.Service.EmailDomains.Data.PostgreSql/WC.Service.EmailDomains.Data.PostgreSql.csproj src/WC.Service.EmailDomains.Data.PostgreSql/
COPY src/WC.Service.EmailDomains.Data/WC.Service.EmailDomains.Data.csproj src/WC.Service.EmailDomains.Data/
COPY src/WC.Service.EmailDomains.Domain.Abstractions/WC.Service.EmailDomains.Domain.Abstractions.csproj src/WC.Service.EmailDomains.Domain.Abstractions/

RUN dotnet restore src/WC.Service.EmailDomains.API/WC.Service.EmailDomains.API.csproj

COPY src/ .
WORKDIR /src/WC.Service.EmailDomains.API
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WC.Service.EmailDomains.API.dll"]
