using System;
using CitiBank.Services.AccountServices.Commands;

namespace CitiBank.Api.Dtos.Accounts
{
    public class TransferDto 
    {
        public Guid OriginId { get; set; }
        public Guid DestinationId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public static implicit operator TransferAccountCommand(TransferDto transferDto)
        {
            return new TransferAccountCommand(transferDto.OriginId,transferDto.DestinationId, transferDto.Amount, transferDto.Description);
        }
    }
}