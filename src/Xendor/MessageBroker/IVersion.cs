using System;

namespace Xendor.MessageBroker
{
    public interface IVersion
    {
        Guid AggregateId { get; }
        int Number { get; }

        long TimeStamp { get; }
    }
}