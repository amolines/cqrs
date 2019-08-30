using System;
using System.Collections.Generic;

namespace Xendor.MessageBroker
{
    public class Envelope : IEnvelope
    {
        public Envelope(Guid aggregateId, int version, long timeStamp, IDictionary<string, object> payload, string contentType)
        {
            AggregateId = aggregateId;
            Version = version;
            TimeStamp = timeStamp;
            Payload = payload;
            ContentType = contentType;
        }



        public Guid AggregateId { get;  }
        public int Version { get; }
        public long TimeStamp { get;  }
        public IDictionary<string, object> Payload { get; }
        public string ContentType { get; }
    }
}