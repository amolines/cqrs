using System;
using CitiBank.Domain.AggregatesModel.ProductAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class ProductCreatedEventConsumer : EventConsumer<ProductCreatedEvent>
    {
        private ProductCreatedEventConsumer(IMessageBroker messageBroker)
            :base(messageBroker)
        {}
        public static Func<ProductCreatedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new ProductCreatedEventConsumer(messageBroker);
        }
    }
}