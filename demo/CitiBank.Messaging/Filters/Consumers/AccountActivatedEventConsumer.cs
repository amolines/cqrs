using System;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class AccountActivatedEventConsumer : EventConsumer<AccountActivatedEvent>
    {
        private AccountActivatedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<AccountActivatedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new AccountActivatedEventConsumer(messageBroker);
        }
    }
}