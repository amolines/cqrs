using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing
{
    public class ApplyHandlerManager<TAggregate> : IApplyHandlerManager
        where TAggregate : IAggregateRoot
    {
        protected ApplyHandlerManager(TAggregate aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }
        protected TAggregate AggregateRoot { get; }
        public void Invoke(Event @event)
        {
            this.Invoke("Handle", @event);
        }
    }
}