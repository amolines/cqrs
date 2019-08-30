﻿using System.Collections.Generic;
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
            "INSERT INTO client (AggregateId, Version,TimeStamp, Name, LastName, Email) " +
            "VALUES " +
            " (@AggregateId, @Version, @TimeStamp, @Name, @LastName, @Email)";
    }
}