FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 60363
#EXPOSE 44362

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CarDealerApi/CarDealerApi.csproj", "CarDealerApi/"]
RUN dotnet restore CarDealerApi/CarDealerApi.csproj
COPY . .
WORKDIR /src/CarDealerApi
RUN dotnet build CarDealerApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CarDealerApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CarDealerApi.dll"]
