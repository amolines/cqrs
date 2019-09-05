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
        private async Task CreateVersion(Guid aggregateId, int number, long timeStamp)
        {
            var value = await CurrentVersion(aggregateId);
            if (value.Equals(0))
            {
                var version = new Version(aggregateId, number, timeStamp);
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
        private async Task ChangeVersion(Guid aggregateId, int number, long timeStamp)
        {
            var value = await CurrentVersion(aggregateId);
            if (value.Equals(0))
            {
                throw new VersionNotFoundException(aggregateId);
            }

            if (number > value)
            {
                await _versionRepository.Update(new Version(aggregateId, number, timeStamp));
            }
            else
            {
                throw new VersionInvalidException(aggregateId , value , number);
            }


        }
        public async Task SaveAndCreate(IEnvelope envelope)
        {
            var version = await CurrentVersion(envelope.AggregateId);
            if (version.Equals(0))
            {
                await CreateVersion(envelope.AggregateId, envelope.Version, envelope.TimeStamp);
            }
            else
            {
                if (envelope.Version == version + 1)
                {
                    await ChangeVersion(envelope.AggregateId, envelope.Version, envelope.TimeStamp);
                }
                else
                {
                    throw new VersionInvalidException(envelope.AggregateId, version, envelope.Version);
                }
            }
        }
    }
}