using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.AccountAggregate;
using CitiBank.Services.AccountServices.Commands;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;

namespace CitiBank.Services.AccountServices.Handlers
{
    public class WithdrawalAccountCommandHandler : CommandHandler<WithdrawalAccountCommand, Account>
    {
        public WithdrawalAccountCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository)
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override async Task<ICommandResult> Handle(WithdrawalAccountCommand command)
        {

            var account = await Get(command.Id);
            account.Withdrawals(command.Amount, command.Description);

            return await SaveAndCommit(account);


        }
    }
}