FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/WC.Service.EmailDomains.Domain/WC.Service.EmailDomains.Domain.csproj src/WC.Service.EmailDomains.Domain/
COPY src/WC.Service.EmailDomains.Domain.Abstractions/WC.Service.EmailDomains.Domain.Abstractions.csproj src/WC.Service.EmailDomains.Domain.Abstractions/
COPY src/WC.Service.EmailDomains.CreateDomain/WC.Service.EmailDomains.CreateDomain.csproj src/WC.Service.EmailDomains.CreateDomain/

RUN dotnet restore src/WC.Service.EmailDomains.CreateDomain/WC.Service.EmailDomains.CreateDomain.csproj

COPY src .
WORKDIR /src/WC.Service.EmailDomains.CreateDomain
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY src/WC.Service.EmailDomains.CreateDomain/appsettings.json /app/../..

ENTRYPOINT ["dotnet", "WC.Service.EmailDomains.CreateDomain.dll"]
