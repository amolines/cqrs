using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.Data.DataMappers;
using Xendor.CommandModel.Extensions.Reflection;
using Xendor.EventBus;

namespace Xendor.CommandModel.MySql
{
    public class MySqlEventStorage : EventStorage
    {
        private readonly DbDataReaderToEventsDataMapper _dbDataReaderToEventsDataMapper;
        private readonly EventToDictionaryDataMapper _eventToDictionaryDataMapper;
        public MySqlEventStorage(IEventFactory eventFactory)
        {
            _dbDataReaderToEventsDataMapper = new DbDataReaderToEventsDataMapper(eventFactory);
            _eventToDictionaryDataMapper = new EventToDictionaryDataMapper();
        }

        public override async Task Save(IEnumerable<Event> events, string collectionName)
        {
            var unitOfWork = UnitOfWorkManager.CurrentUnitOfWork();

            foreach (var @event in events)
            {
                var values = _eventToDictionaryDataMapper.Mapper(@event);
                var query = new MySqlEventAppendQuery(@event , values, collectionName);
                await unitOfWork.ExecuteNonQueryAsync(query);

            }


        }

        public override async Task<IEnumerable<Event>> Get(Guid aggregateId, int fromVersion, string collectionName)
        {
            List<Event> events = null;
            var unitOfWork = UnitOfWorkManager.CurrentUnitOfWork();
            DbDataReader reader;
            if (fromVersion > 0)
            {

                var query = new MySqlEventGetFromVersionQuery(aggregateId, fromVersion, collectionName);
                reader = await unitOfWork.ExecuteReaderAsync(query);
            }
            else
            {
                var query = new MySqlEventGetQuery(aggregateId, collectionName);
                reader = await unitOfWork.ExecuteReaderAsync(query);

            }
            events = _dbDataReaderToEventsDataMapper.Mapper(reader);
            return events;
        }

        public override async Task Setup(Assembly assembly)
        {
            var unitOfWork = UnitOfWorkManager.New();
            var aggregateRootEntities = assembly.GetAggregateRootEntities();
            foreach (var aggregateRoot in aggregateRootEntities)
            {
                var query = new MySqlEventCreateCollectionQuery(aggregateRoot.GetCollectionName());
                await unitOfWork.ExecuteNonQueryAsync(query);
            }
            unitOfWork.Commit();
            unitOfWork.Dispose();
        }
    }
}