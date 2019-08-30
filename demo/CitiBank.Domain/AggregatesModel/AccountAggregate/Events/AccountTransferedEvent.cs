using System;
using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Events
{
    [ContentType("account.transfer")]
    public class AccountTransferedEvent : Event
    {
        public AccountTransferedEvent(Guid id, decimal amount, string description, DateTime date)
        {
            Id = id;
            Amount = amount;
            Description = description;
            Date = date;

        }
        public Guid Id { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Date { get; }
    }
}