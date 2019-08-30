using System;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class AccountBalanceChangedEventConsumer : EventConsumer<AccountBalanceChangedEvent>
    {
        private AccountBalanceChangedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<AccountBalanceChangedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new AccountBalanceChangedEventConsumer(messageBroker);
        }
    }
}