using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.CommandModel.MySql
{
    internal class MySqlEventGetFromVersionQuery : Query
    {
        public MySqlEventGetFromVersionQuery(Guid aggregateId, int version, string collectionName)
             : base(new Dictionary<string, object>() { { "@AggregateId", aggregateId }, { "@Version", version } })
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }
        public override string Sql => $"SELECT AggregateId,Version,`TimeStamp`,Payload, ContentType FROM `{CollectionName}_event`  WHERE AggregateId = @AggregateId and Version > @Version ORDER BY Version ASC";
    }
}