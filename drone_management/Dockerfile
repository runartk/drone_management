#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["drone_management/drone_management.csproj", "drone_management/"]
RUN dotnet restore "drone_management/drone_management.csproj"
COPY . .
WORKDIR "/src/drone_management"
RUN dotnet build "drone_management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "drone_management.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "drone_management.dll"]
