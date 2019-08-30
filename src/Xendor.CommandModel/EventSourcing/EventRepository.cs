using System;
using System.Linq;
using System.Threading.Tasks;
using Xendor.CommandModel.Exceptions;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel.EventSourcing
{
    public class EventRepository : IEventRepository
    {
        private readonly IEventStorage _eventStorage;
        private readonly IDomainEventMediator _domainEventMediator;
        public EventRepository(IEventStorage eventStorage ,  IDomainEventMediator domainEventMediator)
        {
            _eventStorage = eventStorage ?? throw new ArgumentNullException(nameof(eventStorage));
            _domainEventMediator = domainEventMediator ?? throw new ArgumentNullException(nameof(domainEventMediator));
        }

        public async Task Save<TAggregate>(TAggregate aggregate)
            where TAggregate : AggregateRoot
        {
            var events = aggregate.FlushUncommittedChanges();
            await _eventStorage.Save(events, typeof(TAggregate).GetCollectionName());
            foreach (var @event in events)
            {
                await _domainEventMediator.SendAsync(@event);
            }
        }

        public async Task<TAggregate> Get<TAggregate>(Guid aggregateId)
            where TAggregate : AggregateRoot
        {
            var aggregate = await LoadAggregate<TAggregate>(aggregateId);

            if (aggregate.Removed)
            {
                throw new AggregateRemovedException(aggregate.Id);
            }

            return aggregate;
        }

        private async Task<TAggregate> LoadAggregate<TAggregate>(Guid id)
            where TAggregate : AggregateRoot
        {
            var events =  await _eventStorage.Get(id, -1, typeof(TAggregate).GetCollectionName());

            if (!events.Any()) throw new AggregateNotFoundException(id);
            var aggregate = AggregateRootFactory<TAggregate>.CreateAggregate(id);
            aggregate.LoadFromHistory(events);
            return aggregate;




        }

    }


    
}