using System;
using System.Reflection;
using System.Threading.Tasks;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.EventSourcing.SnapShotting.Data.DataMappers;
using Xendor.CommandModel.Extensions.Reflection;

namespace Xendor.CommandModel.MySql.SnapShotting
{
    public class MySqlSnapshotStorage : SnapshotStorage
    {
        private readonly DbReaderToSnapShotDataMapper _dbReaderToSnapShotDataMapper;
        private readonly SnapShotToDictionaryDataMapper _snapShotToDictionaryDataMapper;

        public MySqlSnapshotStorage( ISnapshotFactory snapshotFactory)
            : base()
        {
            _dbReaderToSnapShotDataMapper = new DbReaderToSnapShotDataMapper(snapshotFactory);
            _snapShotToDictionaryDataMapper = new SnapShotToDictionaryDataMapper();
        }


        public override async Task<Snapshot> Get(Guid id, string collectionName)
        {
            var unitOfWork =UnitOfWorkManager.CurrentUnitOfWork();
            var query = new MySqlSnapshotGetQuery(id, collectionName);
            var reader = await unitOfWork.ExecuteReaderAsync(query);
            return _dbReaderToSnapShotDataMapper.Mapper(reader);
        }

        public override async Task Save(Snapshot snapshot, string collectionName)
        {
            var unitOfWork = UnitOfWorkManager.CurrentUnitOfWork();
            var values = _snapShotToDictionaryDataMapper.Mapper(snapshot);
            var query = new MySqlSnapshotAppendQuery(values, collectionName);
            await unitOfWork.ExecuteNonQueryAsync(query);

        }
        public override async Task Setup(Assembly assembly)
        {
            var unitOfWork = UnitOfWorkManager.New();
            var aggregateRootEntities = assembly.GetAggregateRootEntities();
            foreach (var aggregateRoot in aggregateRootEntities)
            {
                var query = new MySqlSnapshotCreateCollectionQuery(aggregateRoot.GetCollectionName());
                await unitOfWork.ExecuteNonQueryAsync(query);
            }
            unitOfWork.Commit();
            unitOfWork.Dispose();
        }
    }

}

