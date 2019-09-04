using System;
using System.Threading.Tasks;
using Xendor.MessageBroker.Data;
using Xendor.MessageBroker.Exceptions;

namespace Xendor.MessageBroker
{
    public class VersionService : IVersionService
    {
        private readonly IVersionRepository _versionRepository;
        public VersionService(IVersionRepository versionRepository)
        {
            _versionRepository = versionRepository;
        }
        private async Task CreateVersion(Guid aggregateId, int number)
        {
            var value = await CurrentVersion(aggregateId);
            if (value.Equals(0))
            {
                var version = new Version(aggregateId, number);
                await _versionRepository.Create(version);
            }
            else
            {
                throw new VersionNotFoundException(aggregateId);
            }
        }
        private async Task<int> CurrentVersion(Guid aggregateId)
        {
            var version = await _versionRepository.GetVersion(aggregateId);
            return version?.Number ?? 0;
        }
        private async Task ChangeVersion(Guid aggregateId, int number)
        {
            var value = await CurrentVersion(aggregateId);
            if (value.Equals(0))
            {
                throw new VersionNotFoundException(aggregateId);
            }

            if (number > value)
            {
                await _versionRepository.Update(new Version(aggregateId, number));
            }
            else
            {
                throw new VersionInvalidException(aggregateId , value , number);
            }


        }
        public async Task SaveAndCreate(Guid aggregateId, int number)
        {
            var version = await CurrentVersion(aggregateId);
            if (version.Equals(0))
            {
                await CreateVersion(aggregateId, number);
            }
            else
            {
                if (number == version + 1)
                {
                    await ChangeVersion(aggregateId, number);
                }
                else
                {
                    throw new VersionInvalidException(aggregateId, version, number);
                }
            }
        }
    }
}