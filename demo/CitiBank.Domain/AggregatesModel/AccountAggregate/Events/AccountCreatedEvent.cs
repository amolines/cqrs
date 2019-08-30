using System;
using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Events
{
    [ContentType("account.created")]
    public class AccountCreatedEvent : Event
    {
        public AccountCreatedEvent(string number , Guid clientId, Guid productId)
        {
            Number = number;
            ClientId = clientId;
            ProductId = productId;
        }

        public string Number { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
    }
}