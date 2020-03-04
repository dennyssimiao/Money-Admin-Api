#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MoneyAdmin.WebApi/MoneyAdmin.WebApi.csproj", "src/MoneyAdmin.WebApi/"]
COPY ["src/MoneyAdmin.Infra.Data/MoneyAdmin.Infra.Data.csproj", "src/MoneyAdmin.Infra.Data/"]
COPY ["src/MoneyAdmin.Domain/MoneyAdmin.Domain.csproj", "src/MoneyAdmin.Domain/"]
COPY ["src/MoneyAdmin.Domain.Core/MoneyAdmin.Domain.Core.csproj", "src/MoneyAdmin.Domain.Core/"]
RUN dotnet restore "src/MoneyAdmin.WebApi/MoneyAdmin.WebApi.csproj"
COPY . .
WORKDIR "/src/src/MoneyAdmin.WebApi"
RUN dotnet build "MoneyAdmin.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoneyAdmin.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoneyAdmin.WebApi.dll"]