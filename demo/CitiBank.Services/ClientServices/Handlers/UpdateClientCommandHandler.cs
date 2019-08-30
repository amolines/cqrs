using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.ClientAggregate;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using CitiBank.Services.ClientServices.Commands;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;

namespace CitiBank.Services.ClientServices.Handlers
{
    public class UpdateClientCommandHandler : CommandHandler<UpdateClientCommand, Client>
    {
        public UpdateClientCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository)
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override async Task<ICommandResult> Handle(UpdateClientCommand command)
        {

            var aggregate = await Get(command.Id);
            var employeeUpdatedEvent = new ClientUpdatedEvent(command.FirstName, command.LastName, command.Email);
            aggregate.Update(employeeUpdatedEvent);
            return await SaveAndCommit(aggregate);
        }
    }
}