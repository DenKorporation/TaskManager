FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 143

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["hosts/TaskManager.WebApi/TaskManager.WebApi.csproj", "hosts/TaskManager.WebApi/"]
COPY ["src/TaskManager/Application/Application.csproj", "src/TaskManager/Application/"]
COPY ["src/TaskManager/Domain/Domain.csproj", "src/TaskManager/Domain/"]
COPY ["src/TaskManager/Infrastructure/Infrastructure.csproj", "src/TaskManager/Infrastructure/"]
RUN dotnet restore "hosts/TaskManager.WebApi/TaskManager.WebApi.csproj"
COPY . .
WORKDIR "/src/hosts/TaskManager.WebApi"
RUN dotnet build "./TaskManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaskManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.WebApi.dll"]
