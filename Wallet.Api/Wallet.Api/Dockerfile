FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Wallet.Api.csproj", "./"]
RUN dotnet restore "./Wallet.Api.csproj"
COPY . .
RUN dotnet build "Wallet.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Wallet.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WalletApi.dll"]