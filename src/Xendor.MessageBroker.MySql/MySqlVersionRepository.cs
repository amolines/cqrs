using System;
using Xendor.Data;
using Xendor.MessageBroker.Data;

namespace Xendor.MessageBroker.MySql
{
    public class MySqlVersionRepository : VersionRepository
    {
        public MySqlVersionRepository(IUnitOfWork unitOfWork , string aggregateName) 
            : base(unitOfWork, aggregateName)
        {
        }


        protected override IQuery InitGetVersionQuery(Guid aggregateId, string aggregateName)
        {
            return new GetVersionQuery(aggregateId, aggregateName);
        }

        protected override IQuery InitUpdateVersionQuery(IVersion version, string aggregateName)
        {
            return new UpdateVersionQuery(version.AggregateId, version.Number,version.TimeStamp, aggregateName);
        }

        protected override IQuery InitInsertVersionQuery(IVersion version, string aggregateName)
        {
            return new InsertVersionQuery(version.AggregateId, version.Number, version.TimeStamp, aggregateName);
        }
    }
}