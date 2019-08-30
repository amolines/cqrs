using System;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public abstract class SnapshotAggregateRoot<T> : AggregateRoot
        where T : Snapshot
    {
        protected SnapshotAggregateRoot() 
        {}
        protected SnapshotAggregateRoot(Guid id)
            : base(id)
        {}
        public T GetSnapshot()
        {
            var snapshot = CreateSnapshot();
            snapshot.AggregateId = Id;
            return snapshot;
        }

        public void Restore(T snapshot)
        {
            Id = snapshot.AggregateId;
            Version = snapshot.Version;
            RestoreFromSnapshot(snapshot);
        }

        protected abstract T CreateSnapshot();
        protected abstract void RestoreFromSnapshot(T snapshot);
    }

}
