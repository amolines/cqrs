using System;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class AccountCreatedEventConsumer : EventConsumer<AccountCreatedEvent>
    {
        private AccountCreatedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<AccountCreatedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new AccountCreatedEventConsumer(messageBroker);
        }
    }
}