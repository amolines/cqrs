using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.ProductAggregate;
using CitiBank.Services.ProductServices.Commands;
using Xendor;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.Data;
using Xendor.EventBus;

namespace CitiBank.Services.ProductServices.Handlers
{
    public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, Product>
    {
        public CreateProductCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository, IEventBus eventBus) 
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }


        public override  async Task<ICommandResult> Handle(CreateProductCommand command)
        {
      
            var aggregate = new Product(
                IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString),
                command.Name,
                command.ProductType);
            return await SaveAndCommit(aggregate);
        }
    }
}