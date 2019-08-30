FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["demo/CitiBank.View/CitiBank.View.csproj", "demo/CitiBank.View/"]
RUN dotnet restore "demo/CitiBank.View/CitiBank.View.csproj"
COPY . .
WORKDIR "/src/demo/CitiBank.View"
RUN dotnet build "CitiBank.View.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CitiBank.View.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CitiBank.View.dll"]