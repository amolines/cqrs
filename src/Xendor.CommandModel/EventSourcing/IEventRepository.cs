using System;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing
{
    public interface IEventRepository : ISingletonLifestyle
    {
        Task Save<TAggregate>(TAggregate aggregate)
            where TAggregate : AggregateRoot;
        Task<TAggregate> Get<TAggregate>(Guid aggregateId)
            where TAggregate : AggregateRoot;
    }
}