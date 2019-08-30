using System;
using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Events
{
    [ContentType("account.changed")]
    public class AccountBalanceChangedEvent : Event
    {
        public AccountBalanceChangedEvent(Guid id, DateTime date,  decimal amount, string description , Guid clientId)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
            ClientId = clientId;
        }
        public Guid Id { get; }
        public Guid ClientId { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Description { get; }
    }
}