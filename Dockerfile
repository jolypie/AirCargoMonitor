
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CargosMonitor.csproj", "./"]
RUN dotnet restore "./CargosMonitor.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "CargosMonitor.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CargosMonitor.dll"]
