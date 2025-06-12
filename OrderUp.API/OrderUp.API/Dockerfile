# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy everything
COPY . .

# Restore and publish
RUN dotnet restore "./OrderUp.API/OrderUp.API.csproj"
RUN dotnet publish "./OrderUp.API/OrderUp.API.csproj" -c Release -o /out

# Use the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["dotnet", "OrderUp.API.dll"]
