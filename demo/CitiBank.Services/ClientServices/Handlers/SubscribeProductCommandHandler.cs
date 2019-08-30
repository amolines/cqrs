using System.Collections.Generic;
using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.ClientAggregate;
using CitiBank.Domain.AggregatesModel.ProductAggregate;
using CitiBank.Services.ClientServices.Commands;
using Xendor.CommandModel;
using Xendor.CommandModel.Command;
using Xendor.CommandModel.Validation;
using Xendor.Data;

namespace CitiBank.Services.ClientServices.Handlers
{
    public class SubscribeProductCommandHandler : CommandHandler<SubscribeProductCommand, Client>
    {
        public SubscribeProductCommandHandler(IUnitOfWorkManager unitOfWorkManager, IAggregateRootRepository aggregateRootRepository)
            : base(unitOfWorkManager, aggregateRootRepository)
        {
        }

        public override async Task<ICommandResult> Handle(SubscribeProductCommand command)
        {
            var product = await Get<Product>(command.ProductId);
            if (product != null)
            {
                var aggregate = await Get(command.ClientId);
                aggregate.SubscribeProduct(command.ProductId, command.Number);
                return await SaveAndCommit(aggregate);
            }

            var brokenDomainRuleBuilder = new ErrorBuilder();
            var error = brokenDomainRuleBuilder
                .SetErrorCode("0x008")
                .SetMessage("The product not exists")
                .Build();


            var errors = new List<Error>()
            {
                error
            };
            return new CommandResult(errors);




        }
    }
}