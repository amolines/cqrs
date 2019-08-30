using System;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate.Entities
{
    public class Client : AggregateMember
    {
        public Client(Guid id, string fullName , string email)
            : base(id)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; }
        public string Email { get; }
    }
}