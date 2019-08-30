using System;
using Xendor.CommandModel.Command;

namespace CitiBank.Services.AccountServices.Commands
{
    public class DepositAccountCommand : ICommand
    {
        public DepositAccountCommand(Guid id , decimal amount , string description)
        {
            Id = id;
            Amount = amount;
            Description = description;

        }
        public Guid Id { get; }
        public decimal Amount { get; }
        public string Description { get; }
    }
}