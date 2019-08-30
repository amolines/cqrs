using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.CommandModel.EventSourcing.SnapShotting.Data.DataMappers
{
    public class SnapShotToDictionaryDataMapper : IDataMapper<Snapshot, IDictionary<string, object>>
    {
        public IDictionary<string, object> Mapper(Snapshot source)
        {

            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId },
                { "@Version", source.Version },
                { "@ContentType", source.ContentType },
                { "@Payload", Newtonsoft.Json.JsonConvert.SerializeObject(source.Payload) }
            };
            return parameters;
        }
    }


  
}