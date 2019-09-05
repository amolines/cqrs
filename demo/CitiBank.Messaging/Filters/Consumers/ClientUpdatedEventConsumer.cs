using System;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class ClientUpdatedEventConsumer : EventConsumer<ClientUpdatedEvent>
    {
        private ClientUpdatedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<ClientUpdatedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new ClientUpdatedEventConsumer(messageBroker);
        }
    }
}