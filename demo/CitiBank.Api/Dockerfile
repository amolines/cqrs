FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["demo/CitiBank.Api/CitiBank.Api.csproj", "demo/CitiBank.Api/"]
COPY ["src/Xendor.EventBus.RabbitMQ/Xendor.EventBus.RabbitMQ.csproj", "src/Xendor.EventBus.RabbitMQ/"]
COPY ["src/Xendor/Xendor.csproj", "src/Xendor/"]
COPY ["src/Xendor.ServiceLocator.SimpleInjector/Xendor.ServiceLocator.SimpleInjector.csproj", "src/Xendor.ServiceLocator.SimpleInjector/"]
COPY ["demo/CitiBank.Services/CitiBank.Services.csproj", "demo/CitiBank.Services/"]
COPY ["demo/CitiBank.Domain/CitiBank.Domain.csproj", "demo/CitiBank.Domain/"]
COPY ["src/Xendor.CommandModel/Xendor.CommandModel.csproj", "src/Xendor.CommandModel/"]
COPY ["src/Xendor.CommandModel.MySql/Xendor.CommandModel.MySql.csproj", "src/Xendor.CommandModel.MySql/"]
COPY ["src/Xendor.Data.MySql/Xendor.Data.MySql.csproj", "src/Xendor.Data.MySql/"]
COPY ["src/Xendor.EventBus.MySql/Xendor.EventBus.MySql.csproj", "src/Xendor.EventBus.MySql/"]
RUN dotnet restore "demo/CitiBank.Api/CitiBank.Api.csproj"
COPY . .
WORKDIR "/src/demo/CitiBank.Api"
RUN dotnet build "CitiBank.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CitiBank.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CitiBank.Api.dll"]
