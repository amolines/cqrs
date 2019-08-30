using System.Reflection;
using Xendor.CommandModel.Command;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.EventSourcing.SnapShotting.Strategies.Contracts;
using Xendor.CommandModel.MessageBroker;
using Xendor.Data;
using Xendor.MessageBroker;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.Extensions
{
    public static class CommandSubSystemServiceCollectionExtensions
    {

        public static void AddCommandSubSystem<TCommandBus, TSnapshotStrategy>(this IServiceLocator services, Assembly assembly)
            where TCommandBus : class, ICommandBus
            where TSnapshotStrategy : class, ISnapshotStrategy
        {

            services.Register<IMessageBroker, CommandMessageBroker>();
            services.Register<IUnitOfWorkManager, UnitOfWorkManager>();
            services.Register<IEventRepository, EventRepository>();
            services.Register<ISnapshotRepository, SnapshotRepository>();
            services.Register<ISnapshotFactory>(new SnapshotFactory(assembly));
            services.Register<IEventFactory>(new EventFactory(assembly));
            services.Register<IAggregateRootRepository, AggregateRootRepository>();
            services.Register<IDomainEventMediator, DomainEventMediator>();
            services.Register<ICommandHandlerFactory, CommandHandlerFactory>();
            services.Register<IDomainEventHandlerFactory, DomainEventHandlerFactory>();
            services.Register<ICommandBus, TCommandBus>();
            services.Register<ISnapshotStrategy, TSnapshotStrategy>();
        }

    }
}