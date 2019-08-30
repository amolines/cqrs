using System;
using System.Threading.Tasks;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.Exceptions;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel
{
    public class AggregateRootRepository : IAggregateRootRepository
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISnapshotRepository _snapshotRepository;

        public AggregateRootRepository(IEventRepository eventRepository, ISnapshotRepository snapshotRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _snapshotRepository = snapshotRepository ?? throw new ArgumentNullException(nameof(snapshotRepository));
        }

        private bool IsSnapshotable(Type aggregateType)
        {
            return aggregateType.IsSnapshotable();
        }

        public async Task Save<T>(T aggregate)
            where T : AggregateRoot
        {
            if (IsSnapshotable(typeof(T)))
            {
                await _snapshotRepository.Save(aggregate);
            }
            else
            {
                await _eventRepository.Save(aggregate);
            }
        }

        public async Task<T> Get<T>(Guid aggregateId)
            where T : AggregateRoot
        {
            T aggregate;
            if (IsSnapshotable(typeof(T)))
            {
                aggregate = await _snapshotRepository.Get<T>(aggregateId);
            }
            else
            {
                aggregate = await _eventRepository.Get<T>(aggregateId);
            }
            

            if (aggregate.Removed)
            {
                throw new AggregateRemovedException(aggregate.Id);
            }

            return aggregate;

        }
    }
}