using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.CommandModel.MySql.SnapShotting
{
    internal class MySqlSnapshotGetQuery : Query
    {
    
        public MySqlSnapshotGetQuery(Guid aggregateId , string collectionName) 
            : base(new Dictionary<string, object>() { { "@AggregateId", aggregateId } })
       
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }

        public override string Sql => $"SELECT AggregateId,Version,Payload,ContentType FROM `{CollectionName}_snapshot`  WHERE AggregateId = @AggregateId ORDER BY Version DESC LIMIT 1";


    }
}