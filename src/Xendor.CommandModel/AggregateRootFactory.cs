using System;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel
{
    public static class AggregateRootFactory<TAggregate>
        where TAggregate : IAggregateRoot
    {
        public static TAggregate CreateAggregate()
        {
            return (TAggregate)typeof(TAggregate).GetInstance();
        }
        public static TAggregate CreateAggregate(Guid aggregateId)
        {
            return (TAggregate)typeof(TAggregate).GetInstance(aggregateId);
        }
    }
}