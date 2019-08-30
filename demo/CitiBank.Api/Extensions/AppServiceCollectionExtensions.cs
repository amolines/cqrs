using System;
using System.Linq;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using CitiBank.Domain.Handlers;
using CitiBank.Services.AccountServices.Commands;
using CitiBank.Services.AccountServices.Handlers;
using CitiBank.Services.ClientServices.Commands;
using CitiBank.Services.ClientServices.Handlers;
using CitiBank.Services.ProductServices.Commands;
using CitiBank.Services.ProductServices.Handlers;
using Microsoft.Extensions.Configuration;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.CommandModel.EventSourcing.SnapShotting.Strategies;
using Xendor.CommandModel.Extensions;
using Xendor.CommandModel.MySql.Extensions;
using Xendor.EventBus.RabbitMQ.Extensions;
using Xendor.Extensions;
using Xendor.ServiceLocator;

namespace CitiBank.Api.Extensions
{
    public static class AppServiceCollectionExtensions
    {

        public static void InitializeContainer(this IServiceLocator services, IConfiguration configuration)
        {

            services.AddXendor();
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == "CitiBank.Domain");
            services.AddCommandSubSystem<DefaultCommandBus, DefaultSnapshotStrategy>(assembly);
            services.AddEventSourcingMySql(configuration, "connectionString");
            services.AddRabbitMqEventBus(configuration, "rabbitConnectionString");
            //Command Handlers
            services.Register<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.Register<ICommandHandler<CreateClientCommand>, CreateClientCommandHandler>();
            services.Register<ICommandHandler<SubscribeProductCommand>, SubscribeProductCommandHandler>();
            services.Register<ICommandHandler<UpdateClientCommand>, UpdateClientCommandHandler>();
            services.Register<ICommandHandler<DepositAccountCommand>, DepositAccountCommandHandler>();
            services.Register<ICommandHandler<WithdrawalAccountCommand>, WithdrawalAccountCommandHandler>();
            services.Register<ICommandHandler<TransferAccountCommand>, TransferAccountCommandHandler>();
            //Domain Event Handlers
            services.Register<IDomainEventHandler<ProductSubscribedEvent>>(typeof(ProductSubscribedEventHandler));

            services.Register<IDomainEventHandler<AccountTransferedEvent>>(typeof(AccountTransferedEventHanlder));


        }

    }

    

}