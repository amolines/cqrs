using System;
using System.Linq;
using Xendor.CommandModel.EventSourcing.SnapShotting.Strategies.Contracts;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel.EventSourcing.SnapShotting.Strategies
{
    
    public class DefaultSnapshotStrategy : ISnapshotStrategy
    {
        private const int SnapshotInterval = 2;
        
        public bool IsSnapshotable(Type aggregateType)
        {
            return aggregateType.IsSnapshotable();
        }

        public bool ShouldMakeSnapShot(IAggregateRoot aggregate)
        {
            if (!IsSnapshotable(aggregate.GetType()))
                return false;

            var i = aggregate.Version;
            for (var j = 0; j < aggregate.UncommittedChanges.Count(); j++)
                if (++i % SnapshotInterval == 0 && i != 0)
                    return true;
            return false;
        }
    }
}