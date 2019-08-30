using System;

namespace Xendor.CommandModel.EventSourcing.SnapShotting.Strategies.Contracts
{
   
    public interface ISnapshotStrategy
    {
      
        bool ShouldMakeSnapShot(IAggregateRoot aggregate);

      
        bool IsSnapshotable(Type aggregateType);
    }
}