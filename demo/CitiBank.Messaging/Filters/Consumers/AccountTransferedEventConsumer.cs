using System;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.EventBus;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.Consumers
{
    public class AccountTransferedEventConsumer : EventConsumer<AccountTransferedEvent>
    {
        private AccountTransferedEventConsumer(IMessageBroker messageBroker)
            : base(messageBroker)
        { }
        public static Func<AccountTransferedEventConsumer> ConsumerFactory(IMessageBroker messageBroker)
        {
            return () => new AccountTransferedEventConsumer(messageBroker);
        }
    }
}