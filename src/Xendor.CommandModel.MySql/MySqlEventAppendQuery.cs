using System.Collections.Generic;
using Xendor.Data;
using Xendor.EventBus;

namespace Xendor.CommandModel.MySql
{
    internal class MySqlEventAppendQuery : Query
    {
        public MySqlEventAppendQuery(Event @event , IDictionary<string,object> values , string collectionName)
            : base(@event,values)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; }

        public override string Sql => $"INSERT INTO `{CollectionName}_event` (AggregateId,Version,TimeStamp,Payload,ContentType) VALUES(@AggregateId,@Version,@TimeStamp,@Payload,@ContentType)";

    }
}