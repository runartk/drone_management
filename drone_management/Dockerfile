# https://softchris.github.io/pages/dotnet-dockerize.html#create-a-dockerfile

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Command line invocation
ENTRYPOINT [ "dotnet", "drone-management.dll" ]