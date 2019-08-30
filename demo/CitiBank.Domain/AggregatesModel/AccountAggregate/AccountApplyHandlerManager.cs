using CitiBank.Domain.AggregatesModel.AccountAggregate.Entities;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Events;
using Xendor.CommandModel.EventSourcing;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate
{
    public partial class Account
    {
        #region AggregateRoot
        protected override IApplyHandlerManager CreateEventHandlerManager()
        {
            return new AccountApplyHandlerManager(this);
        }
        #endregion

        #region EventHandler

        private class AccountApplyHandlerManager : ApplyHandlerManager<Account>,
            IApplyHandler<AccountCreatedEvent>,
            IApplyHandler<AccountActivatedEvent>,
            IApplyHandler<AccountBalanceChangedEvent>,
            IApplyHandler<AccountDisabledEvent>,
            IApplyHandler<AccountTransferedEvent>
        {
            public AccountApplyHandlerManager(Account aggregateRoot)
                : base(aggregateRoot)
            {
            }
            
            
            public void Handle(AccountCreatedEvent message)
            {
                AggregateRoot.Active = false;
                AggregateRoot.Number = message.Number;
                AggregateRoot.ClientId = message.ClientId;
                AggregateRoot.ProductId = message.ProductId;
                AggregateRoot._operations = new OperationCollection();
            }


            public void Handle(AccountActivatedEvent message)
            {
                AggregateRoot.Active = true;
            }

            public void Handle(AccountBalanceChangedEvent message)
            {
                if (AggregateRoot._operations == null)
                    AggregateRoot._operations = new OperationCollection();
                var operation = new Operation(message.Id, message.Date, AggregateRoot.Amount,
                    message.Amount, message.Description);
                AggregateRoot._operations.Add(operation);
                AggregateRoot.Amount += message.Amount;
            }

            public void Handle(AccountDisabledEvent message)
            {
                AggregateRoot.Active = false;
            }

            public void Handle(AccountTransferedEvent message)
            {
              
            }
        }

        #endregion
    }
}
