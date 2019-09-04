using System;

namespace Xendor.MessageBroker
{
    public class Version : IVersion
    {
        public Version(Guid aggregateId, int number)
        {
            AggregateId = aggregateId;
            Number = number;
        }
        public Guid AggregateId { get; }
        public int Number { get; }

        public static Version FromIEnvelope(IEnvelope envelope)
        {
            return new Version(envelope.AggregateId, envelope.Version);
        }
    }
}