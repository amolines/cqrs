using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.CommandModel.MySql.SnapShotting
{
    internal class MySqlSnapshotAppendQuery : Query
    {
    
        public MySqlSnapshotAppendQuery(IDictionary<string, object> values, string collectionName)
             : base(values)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }

        public override  string Sql =>
            $"INSERT INTO `{CollectionName}_snapshot` (AggregateId,Version,Payload,ContentType) VALUES(@AggregateId,@Version,@Payload,@ContentType)";
    }
}