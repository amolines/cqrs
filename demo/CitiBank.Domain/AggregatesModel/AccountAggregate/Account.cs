using System;
using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Entities;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Rules;
using Xendor;
using Xendor.CommandModel;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.Validation;
using Xendor.Reflection;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate
{

    [CollectionName("accounts")]
    public partial class Account : SnapshotAggregateRoot<AccountSnapshot>
    {
        #region Attributes

        private OperationCollection _operations;

        private IRuleManager<Account> _domainRuleManager;

        #endregion

        #region Constructors
        public Account()
        {
            _domainRuleManager = new RuleManager<Account>(new ObjectInfo());
        }

        public Account(Guid id)
            : base(id)
        {
            _domainRuleManager = new RuleManager<Account>(new ObjectInfo());
        }

        public Account(Guid id , string number , Guid clientId, Guid productId)
            : base(id)
        {
            ApplyChange(new AccountCreatedEvent( number, clientId, productId));
        }

        #endregion
        #region Properties

        public Guid ClientId { get; private set; }

        public Guid ProductId { get; private set; }

        public string Number { get; private set; }

        public decimal Amount { get; private set; }

        public bool Active { get; private set; }


        public IEnumerable<Operation> Operations => _operations.Entities;

        #endregion


        public void Activate()
        {
            ApplyChange(new AccountActivatedEvent());
        }

        public void Disable()
        {
            ApplyChange(new AccountDisabledEvent());
        }

        public void Deposit(decimal amount, string description)
        {
            ApplyChange(new AccountBalanceChangedEvent(
                IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString)
                ,DateTime.Today,  amount, description,ClientId ));
        }
        public void Withdrawals(decimal amount, string description)
        {
            var brokenDomainRuleCollection = _domainRuleManager.Validate<WithdrawalsRule, WithdrawalsRule.WithdrawalsRuleParameter>
                (this, WithdrawalsRule.CreateParameter(amount, Amount));

            if (brokenDomainRuleCollection.Errors > 0)
            {
                AddErrors(brokenDomainRuleCollection);
            }


            ApplyChange(new AccountBalanceChangedEvent(
                IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString)
                , DateTime.Today, -1* amount, description,ClientId));
        }

        public void Transfer(decimal amount, string description , Guid destination)
        {
            Withdrawals(amount , description);
            ApplyChange(new AccountTransferedEvent(destination,amount,description, DateTime.Today));
        }





    }
}
