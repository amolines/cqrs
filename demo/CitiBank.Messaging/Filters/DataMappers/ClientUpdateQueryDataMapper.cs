using System.Collections.Generic;
using CitiBank.Messaging.Filters.Queries;
using Xendor.Data;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.DataMappers
{
    public class ClientUpdateQueryDataMapper : IDataMapper<IEnvelope, ClientUpdateQuery>
    {
        public ClientUpdateQuery Mapper(IEnvelope source)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId},

            };
            if(source.Payload.ContainsKey("FirstName"))
                parameters.Add("@Name", source.Payload["FirstName"] );

            if (source.Payload.ContainsKey("LastName"))
                parameters.Add("@LastName", source.Payload["LastName"]);

            if (source.Payload.ContainsKey("Email"))
                parameters.Add("@Email", source.Payload["Email"]);



            return new ClientUpdateQuery(parameters);
        }
    }
}