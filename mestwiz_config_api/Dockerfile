#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mestwiz.config.api/mestwiz.config.api.csproj", "mestwiz.config.api/"]
COPY ["mestwiz.config.api.entities/mestwiz.config.api.entities.csproj", "mestwiz.config.api.entities/"]
COPY ["mestwiz.config.data.controller/mestwiz.config.data.controller.csproj", "mestwiz.config.data.controller/"]
COPY ["mestwiz.config.data.access/mestwiz.config.data.access.csproj", "mestwiz.config.data.access/"]
COPY ["mestwiz.config.data.entities/mestwiz.config.data.entities.csproj", "mestwiz.config.data.entities/"]
COPY ["mestwiz.config.api.logic/mestwiz.config.api.logic.csproj", "mestwiz.config.api.logic/"]
RUN dotnet restore "mestwiz.config.api/mestwiz.config.api.csproj"
COPY . .
WORKDIR "/src/mestwiz.config.api"
RUN dotnet build "mestwiz.config.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mestwiz.config.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mestwiz.config.api.dll"]