using System;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Entities
{
    public class Operation : AggregateMember
    {
        public Operation(Guid id , DateTime date, decimal total, decimal amount, string description)
            :base(id)
        {
            Date = date;
            Total = total;
            Amount = amount;
            Description = description;
        }

        public DateTime Date { get; }
        public decimal Total { get; }
        public decimal Amount { get; }
        public string Description { get; }
    }
}