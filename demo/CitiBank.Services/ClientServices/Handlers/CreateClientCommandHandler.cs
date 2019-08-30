using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.ClientAggregate;
using CitiBank.Services.ClientServices.Commands;
using Xendor;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;

namespace CitiBank.Services.ClientServices.Handlers
{
    public class CreateClientCommandHandler : CommandHandler<CreateClientCommand, Client>
    {
        public CreateClientCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository) 
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override  async Task<ICommandResult> Handle(CreateClientCommand command)
        {
      
            var aggregate = new Domain.AggregatesModel.ClientAggregate.Client(
                IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString),
                command.FirstName,
                command.LastName,
                command.Email);
            return await SaveAndCommit(aggregate);
        }
    }
}