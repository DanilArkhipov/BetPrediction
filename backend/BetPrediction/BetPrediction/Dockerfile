FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BetPrediction/BetPrediction.csproj", "BetPrediction/"]
RUN dotnet restore "BetPrediction/BetPrediction.csproj"
COPY . .
WORKDIR "/src/BetPrediction"
RUN dotnet build "BetPrediction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BetPrediction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BetPrediction.dll"]
