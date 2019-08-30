using System;
using System.Collections.Generic;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing
{
    public interface IEventFactory : ISingletonLifestyle
    {
        IDictionary<string, Type> KnownTypes { get; }

        Event Create(Guid id, int version, long timeStamp, string json, string contentType);
    }
}