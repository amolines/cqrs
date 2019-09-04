using System;

namespace Xendor.MessageBroker.Exceptions
{
    public class VersionNotFoundException : Exception
    {
        public VersionNotFoundException(Guid aggregateId)
            : base($"Version not found for the aggregateid [{aggregateId}]")
        {

        }
    }
}