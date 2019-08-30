using System;
using System.Collections.Generic;
using CitiBank.Domain.AggregatesModel.AccountAggregate.Entities;
using Xendor;
using Xendor.CommandModel.EventSourcing.SnapShotting;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate
{
    [ContentType("account.snapshot")]
    public class AccountSnapshot : Snapshot
    {
        public AccountSnapshot(string number, decimal amount,bool active, Guid clientId, IEnumerable<Operation> operations)
        {
            Number = number;
            Amount = amount;
            Active = active;
            ClientId = clientId;
            Operations = operations;
        }

        public string Number { get;  }

        public decimal Amount { get;  }

        public bool Active { get;  }

        public Guid ClientId { get; }

        public IEnumerable<Operation> Operations { get; }

    }

    public partial class Account
    {
        #region SnapshotAggregateRoot
        protected override AccountSnapshot CreateSnapshot()
        {
            return new AccountSnapshot( Number, Amount, Active,ClientId, _operations.Entities);
        }
        protected override void RestoreFromSnapshot(AccountSnapshot snapshot)
        {
            Number = snapshot.Number;
            Amount = snapshot.Amount;
            Active = snapshot.Active;
            ClientId = snapshot.ClientId;
            _operations = new OperationCollection(snapshot.Operations);
        }
        #endregion
    }
}