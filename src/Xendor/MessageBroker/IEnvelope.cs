using System;
using System.Collections.Generic;

namespace Xendor.MessageBroker
{
    public interface IEnvelope 
    {
         Guid AggregateId { get; }
         int Version { get; }
         long TimeStamp { get; }
         IDictionary<string, object> Payload { get; }
         string ContentType { get; }

    }
}