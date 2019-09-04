using System.Collections.Generic;
using Xendor.Data;

namespace CitiBank.Messaging.Filters.Queries
{
    public class AccountUpdateQuery : Query
    {
        public AccountUpdateQuery(IDictionary<string, object> values)
            : base(values)
        {

        }
        public override string Sql =>
            " SELECT  @AccountId := id from accounts where AggregateId = @AggregateId; " +
            " INSERT INTO operations (Date, Amount,Description, AccountId) VALUES  (@Date, @Amount, @Description, @AccountId); " +
            " UPDATE accounts SET Version = @Version, TimeStamp = @TimeStamp WHERE  Id = @AccountId; ";
    }
}