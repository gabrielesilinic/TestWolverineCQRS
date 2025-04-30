FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestWolverineCQRS/TestWolverineCQRS.csproj", "TestWolverineCQRS/"]
RUN dotnet restore "TestWolverineCQRS/TestWolverineCQRS.csproj"
COPY . .
WORKDIR "/src/TestWolverineCQRS"
RUN dotnet build "TestWolverineCQRS.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TestWolverineCQRS.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWolverineCQRS.dll"]
