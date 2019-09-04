using System.Collections.Generic;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class ProductCreateQuery : Query
    {
        public ProductCreateQuery(IDictionary<string, object> values)
            : base(values)
        {

        }
        public override string Sql =>
            "INSERT INTO products (AggregateId, Version,TimeStamp, Name, ProductType) " +
            "VALUES " +
            " (@AggregateId, @Version, @TimeStamp, @Name, @ProductType)";
    }
}
