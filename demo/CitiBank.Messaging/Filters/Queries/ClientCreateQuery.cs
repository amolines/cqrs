using System.Collections.Generic;
using System.Text;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class ClientCreateQuery : Query
    {
        public ClientCreateQuery(IDictionary<string, object> values)
            : base(values)
        {

        }
        public override string Sql =>
            "INSERT INTO clients (AggregateId, Name, LastName, Email) " +
            "VALUES " +
            " (@AggregateId,  @Name, @LastName, @Email)";
    }
}