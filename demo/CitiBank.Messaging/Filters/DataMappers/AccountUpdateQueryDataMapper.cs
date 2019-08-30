using System;
using System.Collections.Generic;
using CitiBank.Messaging.Filters.Queries;
using Xendor.Data;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.DataMappers
{
    public class AccountUpdateQueryDataMapper : IDataMapper<IEnvelope, AccountUpdateQuery>
    {
        public AccountUpdateQuery Mapper(IEnvelope source)
        {
            DateTime date;
            DateTime.TryParse(source.Payload["Date"].ToString(), out date);
        



            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId},
                { "@Version", source.Version },
                { "@TimeStamp", source.TimeStamp },
                { "@Date", date },
                { "@Description", source.Payload["Description"] },
                { "@Amount", source.Payload["Amount"] }
            };
            return new AccountUpdateQuery(parameters);
        }
    }
}