using System;
using System.Collections.Generic;
using System.Data.Common;
using Xendor.Data;
using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing.Data.DataMappers
{
    public class DbDataReaderToEventsDataMapper : IDataMapper<DbDataReader, List<Event>>
    {
        private readonly IEventFactory _eventFactory;
        public DbDataReaderToEventsDataMapper(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory ?? throw new ArgumentNullException(nameof(eventFactory));
        }
        public List<Event> Mapper(DbDataReader source)
        {
            var events = new List<Event>();
            while (source.Read())
            {
                var id = source.GetGuid(0);
                var version = source.GetInt16(1);
                var timeStamp = source.GetInt64(2);
                var contentType = source.GetString(4);
                var json = source.GetString(3);
                var @event = _eventFactory.Create(id, version, timeStamp, json, contentType);
                events.Add(@event);
            }
            return events;
        }
    }
}