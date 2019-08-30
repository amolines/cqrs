using System;
using System.Threading.Tasks;
using CitiBank.Domain.AggregatesModel.AccountAggregate;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using Xendor;
using Xendor.CommandModel;

namespace CitiBank.Domain.Handlers
{
    public class ProductSubscribedEventHandler : IDomainEventHandler<ProductSubscribedEvent>
    {
        private readonly IAggregateRootRepository _aggregateRootRepository;
        public ProductSubscribedEventHandler(IAggregateRootRepository aggregateRootRepository)
        {
            _aggregateRootRepository = aggregateRootRepository ?? throw new ArgumentNullException(nameof(aggregateRootRepository));
        }



        public async Task HandleAsync(ProductSubscribedEvent @event)
        {
            var client = await _aggregateRootRepository.Get<AggregatesModel.ClientAggregate.Client>(@event.ClientId);

            #region product
            var product = await _aggregateRootRepository.Get<AggregatesModel.ProductAggregate.Product>(@event.ProductId);
            product.SubscribeClient(@event.ClientId, $"{client.FirstName} {client.LastName}", client.Email);
            await _aggregateRootRepository.Save(product);
            #endregion

            #region account
            var aggregate = new Account(IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString), @event.Number, @event.ClientId, @event.ProductId);
            aggregate.Activate();
            await _aggregateRootRepository.Save(aggregate);
            #endregion

        }


    }
}