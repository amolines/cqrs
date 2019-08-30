FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["demo/CitiBank.Messaging/CitiBank.Messaging.csproj", "demo/CitiBank.Messaging/"]
COPY ["src/Xendor.EventBus.RabbitMQ/Xendor.EventBus.RabbitMQ.csproj", "src/Xendor.EventBus.RabbitMQ/"]
COPY ["src/Xendor/Xendor.csproj", "src/Xendor/"]
COPY ["src/Xendor.ServiceLocator.SimpleInjector/Xendor.ServiceLocator.SimpleInjector.csproj", "src/Xendor.ServiceLocator.SimpleInjector/"]
COPY ["src/Xendor.MessageModel/Xendor.MessageModel.csproj", "src/Xendor.MessageModel/"]
COPY ["src/Xendor.Data.MySql/Xendor.Data.MySql.csproj", "src/Xendor.Data.MySql/"]
RUN dotnet restore "demo/CitiBank.Messaging/CitiBank.Messaging.csproj"
COPY . .
WORKDIR "/src/demo/CitiBank.Messaging"
RUN dotnet build "CitiBank.Messaging.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CitiBank.Messaging.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CitiBank.Messaging.dll"]