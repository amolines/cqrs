using System;

namespace Xendor.CommandModel.Exceptions
{
    public class AggregateRemovedException : Exception
    {
        public AggregateRemovedException(Guid aggregateId)
            : base($"The aggregate with id {aggregateId} is removed")
        {

        }
    }
}