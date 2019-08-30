using System;
using System.Collections.Generic;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public interface ISnapshotFactory : ISingletonLifestyle
    {
        IDictionary<string, Type> KnownTypes { get; }

        Snapshot Create(Guid id, int version,  string json, string contentType);
    }
}