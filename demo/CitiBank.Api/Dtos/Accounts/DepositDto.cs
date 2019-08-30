using System;
using CitiBank.Services.AccountServices.Commands;

namespace CitiBank.Api.Dtos.Accounts
{
    public class DepositDto
    {

        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public static implicit operator DepositAccountCommand(DepositDto depositDto)
        {
            return new DepositAccountCommand(depositDto.AccountId, depositDto.Amount, depositDto.Description);
        }
    }
}