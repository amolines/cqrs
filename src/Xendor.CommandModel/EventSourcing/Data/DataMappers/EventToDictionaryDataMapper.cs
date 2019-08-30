using System.Collections.Generic;
using Xendor.Data;
using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing.Data.DataMappers
{
    public class EventToDictionaryDataMapper :  IDataMapper<Event, IDictionary<string, object>>
    {
        public IDictionary<string, object> Mapper(Event source)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId },
                { "@Version", source.Version },
                { "@TimeStamp", source.TimeStamp },
                { "@ContentType", source.ContentType },
                { "@Payload", Newtonsoft.Json.JsonConvert.SerializeObject(source.Payload) }
            };
            return parameters;
        }
    }
}