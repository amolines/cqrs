using System.Collections.Generic;
using CitiBank.Messaging.Filters.Queries;
using Xendor.Data;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.DataMappers
{
    public class AccountCreateQueryDataMapper : IDataMapper<IEnvelope, AccountCreateQuery>
    {
        public AccountCreateQuery Mapper(IEnvelope source)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId},
                { "@Version", source.Version },
                { "@TimeStamp", source.TimeStamp },
                { "@ClientAggregateId", source.Payload["ClientId"] },
                { "@ProductAggregateId", source.Payload["ProductId"] },
                { "@Number", source.Payload["Number"] }
            };
            return new AccountCreateQuery(parameters);
        }
    }
}