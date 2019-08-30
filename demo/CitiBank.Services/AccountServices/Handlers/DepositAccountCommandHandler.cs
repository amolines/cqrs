using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.AccountAggregate;
using CitiBank.Services.AccountServices.Commands;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;
using Xendor.EventBus;

namespace CitiBank.Services.AccountServices.Handlers
{
    public class DepositAccountCommandHandler : CommandHandler<DepositAccountCommand, Account>
    {
        public DepositAccountCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository, IEventBus eventBus)
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override async Task<ICommandResult> Handle(DepositAccountCommand command)
        {

            var account = await Get(command.Id);
            account.Deposit(command.Amount, command.Description);

            return await SaveAndCommit(account);


        }
    }
}