using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.MessageBroker.MySql
{
    internal class InsertVersionQuery : Query
    {
        private readonly string _aggregateName;
        public InsertVersionQuery(Guid aggregateId, int version, string aggregateName)
            : base(new Dictionary<string, object>() {{"@AggregateId", aggregateId}, {"@Version", version}})
        {
            _aggregateName = aggregateName;
        }
        public override string Sql => $"INSERT INTO `{_aggregateName}s.version` (AggregateId,Version) VALUES(@AggregateId,@Version)";
    }
}