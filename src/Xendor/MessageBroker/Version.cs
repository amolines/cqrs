using System;

namespace Xendor.MessageBroker
{
    public class Version : IVersion
    {
        public Version(Guid aggregateId, int number, long timeStamp)
        {
            AggregateId = aggregateId;
            Number = number;
            TimeStamp = timeStamp;
        }
        public Guid AggregateId { get; }
        public int Number { get; }
        public long TimeStamp { get; }

        public static Version FromIEnvelope(IEnvelope envelope)
        {
            return new Version(envelope.AggregateId, envelope.Version, envelope.TimeStamp);
        }
    }
}