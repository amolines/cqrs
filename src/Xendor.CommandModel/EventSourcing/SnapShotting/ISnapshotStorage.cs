using System;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public interface ISnapshotStorage : ISingletonLifestyle
    {
        Task<Snapshot> Get(Guid id, string collectionName);

        Task Save(Snapshot snapshot, string collectionName);

        Task Setup(Assembly assembly);
    }
}
