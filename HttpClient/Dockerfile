FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy all files
COPY ./ ./
RUN dotnet restore

# Publish
WORKDIR /app
RUN dotnet publish -c Release -o out

# Create final repository
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS runtime
WORKDIR /app
LABEL maintainer="az"
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "HttpClient.dll"]