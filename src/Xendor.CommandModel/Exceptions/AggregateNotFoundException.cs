using System;

namespace Xendor.CommandModel.Exceptions
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(Guid aggregateId)
            : base($"The aggregate  id [{aggregateId}] not found")
        {

        }
    }
}