using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing
{
    public interface IEventStorage : ISingletonLifestyle
    {
        Task Save(IEnumerable<Event> events, string collectionName);
        Task<IEnumerable<Event>> Get(Guid aggregateId, int fromVersion, string collectionName);
        Task Setup(Assembly assembly);
    }
}