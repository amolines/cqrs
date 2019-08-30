using CitiBank.Domain.AggregatesModel.ClientAggregate.Entities;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using Xendor.CommandModel.EventSourcing;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate
{
    public partial class Client
    {
        #region AggregateRoot
        protected override IApplyHandlerManager CreateEventHandlerManager()
        {
            return new ClientApplyHandlerManager(this);
        }
        #endregion

        #region EventHandler

        private class ClientApplyHandlerManager : ApplyHandlerManager<Client>,
            IApplyHandler<ClientCreatedEvent>,
            IApplyHandler<ClientUpdatedEvent>,
            IApplyHandler<ProductSubscribedEvent>
        {
            public ClientApplyHandlerManager(Client aggregateRoot)
                : base(aggregateRoot)
            {
            }
            
            public void Handle(ProductSubscribedEvent message)
            {
                if (AggregateRoot._products == null)
                    AggregateRoot._products = new ProductCollection();
                var phone = new Product(message.ProductId, message.Number);
                AggregateRoot._products.Add(phone);
            }

           

            public void Handle(ClientCreatedEvent message)
            {
                AggregateRoot.FirstName = message.FirstName;
                AggregateRoot.LastName = message.LastName;
                AggregateRoot.Email = message.Email;
                AggregateRoot._products = new ProductCollection();
            }

            public void Handle(ClientUpdatedEvent message)
            {
                if (!string.IsNullOrEmpty(message.FirstName))
                    AggregateRoot.FirstName = message.FirstName;
                if (!string.IsNullOrEmpty(message.LastName))
                    AggregateRoot.LastName = message.LastName;
                if (!string.IsNullOrEmpty(message.Email))
                    AggregateRoot.Email = message.Email;
            }


           
        }

        #endregion
    }
}
