FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5284

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Organizzi.csproj", "./"]
RUN dotnet restore "./Organizzi.csproj"
COPY . .
RUN dotnet build "./Organizzi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Organizzi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Organizzi.dll"]
