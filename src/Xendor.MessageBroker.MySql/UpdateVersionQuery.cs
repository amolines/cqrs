using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.MessageBroker.MySql
{
    internal class UpdateVersionQuery : Query
    {
        private readonly string _aggregateName;

        public UpdateVersionQuery(Guid aggregateId, int version, long timeStamp, string aggregateName)
            : base(new Dictionary<string, object>() {{"@AggregateId", aggregateId}, {"@Version", version}, { "@TimeStamp", timeStamp } })
        {
            _aggregateName = aggregateName;
        }
        public override string Sql => $"UPDATE  `{_aggregateName}s.version` SET Version = @Version, TimeStamp = @TimeStamp WHERE AggregateId = @AggregateId";
    }
}