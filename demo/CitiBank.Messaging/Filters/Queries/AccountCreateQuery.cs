using System.Collections.Generic;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class AccountCreateQuery : Query
    {
        public AccountCreateQuery(IDictionary<string, object> values)
            : base(values)
        {

        }
        public override string Sql =>
            "SELECT  @ClientId := id from client where AggregateId = @ClientAggregateId; " +
            "SELECT  @ProductId := id from product where AggregateId = @ProductAggregateId; " +
            "INSERT INTO account (AggregateId, Version,TimeStamp, Number, ClientId, ProductId) " +
            "VALUES " +
            " (@AggregateId, @Version, @TimeStamp, @Number, @ClientId, @ProductId)";
    }
}