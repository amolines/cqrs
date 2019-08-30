using System;
using System.Threading.Tasks;
using CitiBank.Api.Dtos.Accounts;
using CitiBank.Services.AccountServices.Commands;
using Microsoft.AspNetCore.Mvc;
using Xendor.CommandModel.Command;

namespace CitiBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public AccountsController(ICommandBus commandBus)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        // Put api/accounts/{id}/deposits
        [HttpPut("{id}/deposits")]
        public async Task<ICommandResult> Put(Guid id, [FromBody] DepositDto depositDto)
        {
            depositDto.AccountId = id;
            DepositAccountCommand cmd = depositDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }


        // Put api/accounts/{id}/withdrawals
        [HttpPut("{id}/withdrawals")]
        public async Task<ICommandResult> Put(Guid id, [FromBody] WithdrawalDto withdrawalDto)
        {
            withdrawalDto.AccountId = id;
            WithdrawalAccountCommand cmd = withdrawalDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }

        [HttpPut("{id}/Transfer")]
        public async Task<ICommandResult> Put(Guid id, [FromBody] TransferDto transferDto)
        {
            transferDto.OriginId = id;
            TransferAccountCommand cmd = transferDto;
            var commandResult = await _commandBus.Submit(cmd);
            return commandResult;
        }
    }
}