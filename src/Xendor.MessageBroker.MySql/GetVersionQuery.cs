using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.MessageBroker.MySql
{
    internal class GetVersionQuery : Query
    {
        private readonly string _aggregateName;

        public GetVersionQuery(Guid aggregateId, string aggregateName)
            : base(new Dictionary<string, object>() {{"@AggregateId", aggregateId}})
        {
            _aggregateName = aggregateName;
        }
        public override string Sql => $"SELECT  Version FROM  `{_aggregateName}s.version` WHERE AggregateId = @AggregateId";
    }
}