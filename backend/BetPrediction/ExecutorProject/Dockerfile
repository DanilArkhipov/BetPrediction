FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExecutorProject/ExecutorProject.csproj", "ExecutorProject/"]
RUN dotnet restore "ExecutorProject/ExecutorProject.csproj"
COPY . .
WORKDIR "/src/ExecutorProject"
RUN dotnet build "ExecutorProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExecutorProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExecutorProject.dll"]
