using System.Collections.Generic;
using CitiBank.Messaging.Filters.Queries;
using Xendor.Data;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.DataMappers
{
    public class ClientCreateQueryDataMapper : IDataMapper<IEnvelope, ClientCreateQuery>
    {
        public ClientCreateQuery Mapper(IEnvelope source)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId},
                { "@Version", source.Version },
                { "@TimeStamp", source.TimeStamp },
                { "@Name", source.Payload["FirstName"] },
                { "@LastName", source.Payload["LastName"] },
                { "@Email", source.Payload["Email"] }
            };
            return new ClientCreateQuery(parameters);
        }
    }
}