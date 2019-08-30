using System.Collections.Generic;
using CitiBank.Messaging.Filters.Queries;
using Xendor.Data;
using Xendor.MessageBroker;

namespace CitiBank.Messaging.Filters.DataMappers
{
    public class ProductCreateQueryDataMapper : IDataMapper<IEnvelope, ProductCreateQuery>
    {
        public ProductCreateQuery Mapper(IEnvelope source)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@AggregateId", source.AggregateId},
                { "@Version", source.Version },
                { "@TimeStamp", source.TimeStamp },
                { "@Name", source.Payload["Name"] },
                { "@ProductType", source.Payload["ProductType"] }
            };
            return new ProductCreateQuery(parameters);
        }
    }
}
