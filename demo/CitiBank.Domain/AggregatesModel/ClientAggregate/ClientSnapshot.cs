using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Entities;
using Xendor;
using Xendor.CommandModel.EventSourcing.SnapShotting;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate
{
    [ContentType("client.snapshot")]
    public class ClientSnapshot : Snapshot
    {
        public ClientSnapshot(string firstName, string lastName,string email,  IEnumerable<Product> products)
        {
            FirstName = firstName;
            LastName = lastName;
            Products = products;
            Email = email;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public IEnumerable<Product> Products { get; }
    }

    public partial class Client
    {
        #region SnapshotAggregateRoot
        protected override ClientSnapshot CreateSnapshot()
        {
            return new ClientSnapshot( FirstName, LastName, Email, _products.Entities);
        }
        protected override void RestoreFromSnapshot(ClientSnapshot snapshot)
        {
            FirstName = snapshot.FirstName;
            LastName = snapshot.LastName;
            Email = snapshot.Email;
            _products = new ProductCollection(snapshot.Products);
        }
        #endregion
    }
}