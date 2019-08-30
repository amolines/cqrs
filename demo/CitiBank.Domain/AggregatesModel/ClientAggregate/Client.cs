using System;
using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Entities;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Events;
using CitiBank.Domain.AggregatesModel.ClientAggregate.Rules;
using Xendor.CommandModel;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.Validation;
using Xendor.Reflection;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate
{
    [CollectionName("clients")]
    public partial class Client : SnapshotAggregateRoot<ClientSnapshot>
    {
        #region Attributes

        private ProductCollection _products;

        private readonly IRuleManager<Client> _domainRuleManager;

        #endregion

        #region Constructors
        public Client()
        {
            _domainRuleManager = new RuleManager<Client>(new ObjectInfo());
        }

        public Client(Guid id)
            : base(id)
        {
            _domainRuleManager = new RuleManager<Client>(new ObjectInfo());
        }

        public Client(Guid id ,string firstName, string lastName, string email)
            : base(id)
        {
            ApplyChange(new ClientCreatedEvent(firstName, lastName, email));
        }

        #endregion
        #region Properties

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }


        public IEnumerable<Product> Products => _products.Entities;

        #endregion

        public void Update(ClientUpdatedEvent message)
        {
            ApplyChange(message);
        }

        public void SubscribeProduct(Guid  productId, string number)
        {

            var brokenDomainRuleCollection =
                _domainRuleManager
                    .Validate<SubscribeProductRule, SubscribeProductRule.SubscribeProductRuleParameter>
                        (this, SubscribeProductRule.CreateParameter(productId, number));

            if (brokenDomainRuleCollection.Errors > 0)
            {
                AddErrors(brokenDomainRuleCollection);
            }
            else
            {
                ApplyChange(new ProductSubscribedEvent(productId, number,Id));
            }

        }
      
    }
}
