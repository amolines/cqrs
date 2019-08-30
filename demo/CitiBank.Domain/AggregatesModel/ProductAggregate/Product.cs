using System;
using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.ProductAggregate.Entities;
using CitiBank.Domain.AggregatesModel.ProductAggregate.Events;
using Xendor.CommandModel;
using Xendor.CommandModel.EventSourcing.SnapShotting;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate
{

    [CollectionName("products")]
    public partial class Product : SnapshotAggregateRoot<ProductSnapshot>
    {
        private ClientCollection _clients;

        #region Constructors
        public Product()
        { }

        public Product(Guid id)
            : base(id)
        { }

        public Product(Guid id, string name, ProductType productType)
            : base(id)
        {
            ApplyChange(new ProductCreatedEvent(name, productType));
        }

        #endregion

        #region Properties

        public string Name { get; private set; }

        public ProductType ProductType { get; private set; }

        public IEnumerable<Client> Clients => _clients.Entities;

        #endregion

        public void SubscribeClient(Guid clientId, string fullName, string email)
        {
            ApplyChange(new ClientSubscribedEvent(clientId, fullName, email));
        }

    }


}
