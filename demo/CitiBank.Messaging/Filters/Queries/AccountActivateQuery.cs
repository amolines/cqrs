using System.Collections.Generic;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class AccountActivateQuery : Query
    {
        public AccountActivateQuery(IDictionary<string, object> values)
            : base(values)
        {

        }

        public override string Sql =>
            " UPDATE accounts SET activate = true  WHERE AggregateId = @AggregateId  ";

    }
}