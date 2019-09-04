using System;
using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.MessageBroker.MySql
{
    internal class UpdateVersionQuery : Query
    {
        private readonly string _aggregateName;

        public UpdateVersionQuery(Guid aggregateId, int version, string aggregateName)
            : base(new Dictionary<string, object>() {{"@AggregateId", aggregateId}, {"@Version", version}})
        {
            _aggregateName = aggregateName;
        }
        /// <summary>
        /// UPDATE account SET Version = @Version, TimeStamp = @TimeStamp WHERE  Id = @AccountId; 
        /// </summary>
        public override string Sql => $"UPDATE  `{_aggregateName}s.version` SET Version = @Version WHERE AggregateId = @AggregateId";
    }
}