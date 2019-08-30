using System;
using Xendor.CommandModel.Command;

namespace CitiBank.Services.AccountServices.Commands
{
    public class TransferAccountCommand : ICommand
    {
        public TransferAccountCommand(Guid originId, Guid destinationId, decimal amount, string description)
        {
            OriginId = originId;
            DestinationId = destinationId;
            Amount = amount;
            Description = description;
        }
        public Guid OriginId { get; }
        public Guid DestinationId { get; }
        public decimal Amount { get; }
        public string Description { get; }
    }
}