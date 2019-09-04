using System;
using System.Threading.Tasks;
using Xendor.Data;

namespace Xendor.MessageBroker.Data
{
    public abstract class VersionRepository : IVersionRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbDataReaderToVersionDataMapper _dbDataReaderToVersionDataMapper;
        private readonly string _aggregateName;
        protected VersionRepository(IUnitOfWork unitOfWork, string aggregateName)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _aggregateName = aggregateName ?? throw new ArgumentNullException(nameof(aggregateName));
            _dbDataReaderToVersionDataMapper = new DbDataReaderToVersionDataMapper();
        }

        protected abstract IQuery InitGetVersionQuery(Guid aggregateId, string aggregateName);
        protected abstract IQuery InitUpdateVersionQuery(IVersion version, string aggregateName);
        protected abstract IQuery InitInsertVersionQuery(IVersion version, string aggregateName);
        public async Task<IVersion> GetVersion(Guid aggregateId)
        {
            var query = InitGetVersionQuery(aggregateId, _aggregateName);
            var reader = await _unitOfWork.ExecuteReaderAsync(query);
            var version = _dbDataReaderToVersionDataMapper.Mapper(reader);
            return version;
        }
        public async Task Update(IVersion version)
        {
            var query = InitUpdateVersionQuery(version, _aggregateName);
            await _unitOfWork.ExecuteNonQueryAsync(query);
        }
        public async Task Create(IVersion version)
        {
            var query = InitInsertVersionQuery(version , _aggregateName);
            await _unitOfWork.ExecuteNonQueryAsync(query);
        }

        
    }
}