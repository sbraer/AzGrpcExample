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
EXPOSE 5000/tcp
EXPOSE 5001/tcp
ADD ca.crt /usr/local/share/ca-certificates/ca.crt
RUN chmod 644 /usr/local/share/ca-certificates/ca.crt && update-ca-certificates
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "AzGrpcClient.dll"]