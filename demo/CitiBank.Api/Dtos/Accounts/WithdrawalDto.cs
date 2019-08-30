using System;
using CitiBank.Services.AccountServices.Commands;

namespace CitiBank.Api.Dtos.Accounts
{
    public class WithdrawalDto
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public static implicit operator WithdrawalAccountCommand(WithdrawalDto withdrawalDto)
        {
            return new WithdrawalAccountCommand(withdrawalDto.AccountId, withdrawalDto.Amount, withdrawalDto.Description);
        }
    }
}