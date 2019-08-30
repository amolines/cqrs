using System;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class ClientCreatedEventConsumer : EventConsumer<ClientCreatedEvent>
    {
        private ClientCreatedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<ClientCreatedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new ClientCreatedEventConsumer(messageBroker);
        }
    }
}