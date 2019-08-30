using System;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.Data;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public abstract class SnapshotStorage : ISnapshotStorage
    {
        protected IUnitOfWorkManager UnitOfWorkManager => 
            ServiceLocatorFactory.Instance().GetService<IUnitOfWorkManager>();
        public abstract Task<Snapshot> Get(Guid id, string collectionName);
        public abstract Task Save(Snapshot snapshot, string collectionName);
        public abstract Task Setup(Assembly assembly);
    }


}