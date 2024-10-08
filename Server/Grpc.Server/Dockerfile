#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Server/Grpc.Server/Grpc.Server.csproj", "Server/Grpc.Server/"]
COPY ["Server/Grpc.Common/Grpc.Common.csproj", "Server/Grpc.Common/"]
COPY ["Server/Grpc.Server.Data.PostgreSql/Grpc.Server.Data.PostgreSql.csproj", "Server/Grpc.Server.Data.PostgreSql/"]
RUN dotnet restore "./Server/Grpc.Server/./Grpc.Server.csproj"
COPY . .
WORKDIR "/src/Server/Grpc.Server"
RUN dotnet build "./Grpc.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Grpc.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grpc.Server.dll"]