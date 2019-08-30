using System;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    public interface IAggregateRootRepository : ISingletonLifestyle
    {
        Task Save<T>(T aggregate)
            where T : AggregateRoot;

        Task<T> Get<T>(Guid aggregateId)
            where T : AggregateRoot;
    }
}