using System;
using System.Threading.Tasks;

namespace Xendor.MessageBroker.Data
{
    public interface IVersionRepository
    {
        Task<IVersion> GetVersion(Guid aggregateId);
        Task Update(IVersion version);
        Task Create(IVersion version);
    }
}