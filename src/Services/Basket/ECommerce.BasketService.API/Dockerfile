FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Basket/ECommerce.BasketService.API/ECommerce.BasketService.API.csproj", "src/Services/Basket/ECommerce.BasketService.API/"]
COPY ["src/Services/Basket/ECommerce.BasketService.Core/ECommerce.BasketService.Core.csproj", "src/Services/Basket/ECommerce.BasketService.Core/"]
COPY ["src/Services/Basket/ECommerce.BasketService.Infrastructure/ECommerce.BasketService.Infrastructure.csproj", "src/Services/Basket/ECommerce.BasketService.Infrastructure/"]
RUN dotnet restore "src/Services/Basket/ECommerce.BasketService.API/ECommerce.BasketService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Basket/ECommerce.BasketService.API"
RUN dotnet build "ECommerce.BasketService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ECommerce.BasketService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.BasketService.API.dll"]
