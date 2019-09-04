using System;
using System.Collections.Generic;

namespace Xendor.MessageBroker
{
    public interface IEnvelope 
    {
        long TimeStamp { get; }
        IDictionary<string, object> Payload { get; }
        Guid AggregateId { get; }
        int Version { get; }
        string ContentType { get; }
    }
}