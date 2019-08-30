using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.CommandModel.MySql
{
    internal class MySqlEventGetQuery :Query
    {

        public MySqlEventGetQuery(Guid aggregateId, string collectionName)
             : base(new Dictionary<string, object>() { { "@AggregateId", aggregateId } })
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }
        public override string Sql =>
                 $"SELECT AggregateId, Version,`TimeStamp`,Payload,ContentType FROM `{CollectionName}_event`  WHERE AggregateId = @AggregateId ORDER BY Version ASC";
        }
}