using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.AccountAggregate;
using CitiBank.Services.AccountServices.Commands;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;

namespace CitiBank.Services.AccountServices.Handlers
{
    public class TransferAccountCommandHandler : CommandHandler<TransferAccountCommand, Account>
    {
        public TransferAccountCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository)
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override async Task<ICommandResult> Handle(TransferAccountCommand command)
        {

            var origin = await Get(command.OriginId);
            origin.Transfer(command.Amount, command.Description , command.DestinationId);
            return await SaveAndCommit(origin);


        }
    }
}