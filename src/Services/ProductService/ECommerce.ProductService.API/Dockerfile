FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/ProductService/ECommerce.ProductService.API/ECommerce.ProductService.API.csproj", "src/Services/ProductService/ECommerce.ProductService.API/"]
COPY ["src/Services/ProductService/ECommerce.ProductService.Core/ECommerce.ProductService.Core.csproj", "src/Services/ProductService/ECommerce.ProductService.Core/"]
RUN dotnet restore "src/Services/ProductService/ECommerce.ProductService.API/ECommerce.ProductService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/ProductService/ECommerce.ProductService.API"
RUN dotnet build "ECommerce.ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ECommerce.ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.ProductService.API.dll"]
