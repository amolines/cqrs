using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.ProductAggregate.Entities;
using Xendor;
using Xendor.CommandModel.EventSourcing.SnapShotting;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate
{
    [ContentType("product.snapshot")]
    public class ProductSnapshot : Snapshot
    {
        public ProductSnapshot(string name, ProductType productType, IEnumerable<Client> clients)
        {
            Name = name;
            ProductType = productType;
            Clients = clients;
        }

        public string Name { get; }

        public ProductType ProductType { get; }

        public IEnumerable<Client> Clients { get; }

    }
    public partial class Product
    {
        protected override ProductSnapshot CreateSnapshot()
        {
            return new ProductSnapshot(Name, ProductType, _clients.Entities);
        }
        protected override void RestoreFromSnapshot(ProductSnapshot snapshot)
        {
            Name = snapshot.Name;
            ProductType = snapshot.ProductType;
            _clients = new ClientCollection(snapshot.Clients);
        }
    }
}