using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xendor.CommandModel.EventSourcing.SnapShotting.Strategies.Contracts;
using Xendor.CommandModel.Exceptions;
using Xendor.CommandModel.Extensions.Reflection;
using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public class SnapshotRepository : ISnapshotRepository
    {
        private readonly IEventStorage _eventStorage;
        private readonly ISnapshotStrategy _snapshotStrategy;
        private readonly ISnapshotStorage _snapshotStorage;
        private readonly IDomainEventMediator _domainEventMediator;
        public SnapshotRepository(
            IEventStorage eventStorage,
            ISnapshotStorage snapshotStorage,
            ISnapshotStrategy snapshotStrategy,
            IDomainEventMediator domainEventMediator)
        {
            _snapshotStorage = snapshotStorage ?? throw new ArgumentNullException(nameof(snapshotStorage));
            _snapshotStrategy = snapshotStrategy ?? throw new ArgumentNullException(nameof(snapshotStrategy));
            _eventStorage = eventStorage ?? throw new ArgumentNullException(nameof(eventStorage));
            _domainEventMediator = domainEventMediator ?? throw new ArgumentNullException(nameof(domainEventMediator));
        }
        public Task Save<T>(T aggregate)
            where T : AggregateRoot
        {
            return Task.WhenAll(TryMakeSnapshot<T>(aggregate), SaveEvents<T>(aggregate));
        }
        public async Task<T> Get<T>(Guid aggregateId)
            where T : AggregateRoot
        {
            var aggregate = AggregateRootFactory<T>.CreateAggregate(aggregateId);
            var snapshotVersion = await TryRestoreAggregateFromSnapshot(aggregateId, aggregate);


            IEnumerable<Event> events;
            if (snapshotVersion == -1)
            {
                events = await _eventStorage.Get(aggregateId, -1, typeof(T).GetCollectionName());
                if (!events.Any())
                {
                    throw new AggregateNotFoundException(aggregateId);
                }
            }
            else
            {
                events = await _eventStorage.Get(aggregateId, snapshotVersion, typeof(T).GetCollectionName());
            }

            if (events.Any())
            {
                aggregate.LoadFromHistory(events);
            }


            if (aggregate.Removed)
            {
                throw new AggregateRemovedException(aggregate.Id);
            }

            return aggregate;
        }
        private async Task<int> TryRestoreAggregateFromSnapshot<T>(Guid id, T aggregate)
            where T : AggregateRoot
        {
            if (!_snapshotStrategy.IsSnapshotable(typeof(T)))
                return -1;
            var snapshot = await _snapshotStorage.Get(id, typeof(T).GetCollectionName());
            if (snapshot == null)
                return -1;
            aggregate.Invoke("Restore", snapshot);
            return snapshot.Version;
        }
        private Task TryMakeSnapshot<T>(T aggregate)
            where T : AggregateRoot
        {
            if (!_snapshotStrategy.ShouldMakeSnapShot(aggregate))
                return Task.FromResult(0);

            dynamic snapshot = aggregate.Invoke("GetSnapshot");
            snapshot.Version = aggregate.Version + aggregate.UncommittedChanges.Count();

            return _snapshotStorage.Save(snapshot, typeof(T).GetCollectionName());
        }
        private async Task SaveEvents<T>(T aggregate)
            where T : AggregateRoot
        {
            var events = aggregate.FlushUncommittedChanges();
            await _eventStorage.Save(events, typeof(T).GetCollectionName());

            foreach (var @event in events)
            {
                await _domainEventMediator.SendAsync(@event);
            }
        }
    }
}
