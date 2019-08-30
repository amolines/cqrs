using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.Data;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing
{
    public abstract class EventStorage : IEventStorage
    {
        public abstract Task Save(IEnumerable<Event> events, string collectionName);
        public abstract Task<IEnumerable<Event>> Get(Guid aggregateId, int fromVersion, string collectionName);
        public abstract Task Setup(Assembly assembly);

        protected IUnitOfWorkManager UnitOfWorkManager =>
            ServiceLocatorFactory.Instance().GetService<IUnitOfWorkManager>();

    }


}