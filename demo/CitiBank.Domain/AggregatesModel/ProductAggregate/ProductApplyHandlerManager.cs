using CitiBank.Domain.AggregatesModel.ProductAggregate.Entities;
using CitiBank.Domain.AggregatesModel.ProductAggregate.Events;
using Xendor.CommandModel.EventSourcing;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate
{
    public partial class Product
    {
        protected override IApplyHandlerManager CreateEventHandlerManager()
        {
            return new ProductApplyHandlerManager(this);
        }
        private class ProductApplyHandlerManager : ApplyHandlerManager<Product>,
            IApplyHandler<ProductCreatedEvent>,
            IApplyHandler<ClientSubscribedEvent>
        {
            public ProductApplyHandlerManager(Product aggregateRoot)
                : base(aggregateRoot)
            {
            }

            public void Handle(ProductCreatedEvent message)
            {
                AggregateRoot.Name = message.Name;
                AggregateRoot.ProductType = message.ProductType;

            }

            public void Handle(ClientSubscribedEvent message)
            {
                if (AggregateRoot._clients == null)
                    AggregateRoot._clients = new ClientCollection();
                var client = new Client(message.ClientId , message.FullName, message.Email);
                AggregateRoot._clients.Add(client);
            }
        }
    }
}
