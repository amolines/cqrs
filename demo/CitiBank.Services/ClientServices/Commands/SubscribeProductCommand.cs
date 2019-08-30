using System;
using Xendor.CommandModel.Command;

namespace CitiBank.Services.ClientServices.Commands
{
    public class SubscribeProductCommand : ICommand
    {
        public SubscribeProductCommand(Guid productId, string number,  Guid clientId)
        {
            ClientId = clientId;
            ProductId = productId;
            Number = number;
        }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public string Number { get; }

    }
}