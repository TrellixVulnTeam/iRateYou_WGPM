FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WorldWideGadgetShop.WebAPI/WorldWideGadgetShop.WebAPI.csproj", "WorldWideGadgetShop.WebAPI/"]
RUN dotnet restore "WorldWideGadgetShop.WebAPI/WorldWideGadgetShop.WebAPI.csproj"
COPY . .
WORKDIR "/src/WorldWideGadgetShop.WebAPI"
RUN dotnet build "WorldWideGadgetShop.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorldWideGadgetShop.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorldWideGadgetShop.WebAPI.dll"]
