using System;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Entities
{
    public class Product : AggregateMember
    {
        public Product(Guid id, string number)
            : base(id)
        {
            Number = number;
        }
        public string Number { get; }
      


    }
}