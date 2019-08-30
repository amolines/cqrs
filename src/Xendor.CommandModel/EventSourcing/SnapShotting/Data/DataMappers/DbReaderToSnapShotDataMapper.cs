using System;
using System.Data.Common;
using Xendor.Data;

namespace Xendor.CommandModel.EventSourcing.SnapShotting.Data.DataMappers
{
    public class DbReaderToSnapShotDataMapper : IDataMapper<DbDataReader, Snapshot>
    {
        private readonly ISnapshotFactory _snapshotFactory;
        public DbReaderToSnapShotDataMapper(ISnapshotFactory snapshotFactory)
        {
            _snapshotFactory = snapshotFactory ?? throw new ArgumentNullException(nameof(snapshotFactory));
        }
        public Snapshot Mapper(DbDataReader source)
        {
            Snapshot snapshot = null;
            while (source.Read())
            {
                var id = source.GetGuid(0);
                var version = source.GetInt16(1);
                var json = source.GetString(2);
                var contentType = source.GetString(3);
                snapshot = _snapshotFactory.Create(id, version, json, contentType);
            }
            return snapshot;
        }
    }
}