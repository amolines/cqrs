using System;
using System.Threading.Tasks;

namespace Xendor.MessageBroker
{
    public interface IVersionService
    {
        Task SaveAndCreate(IEnvelope envelope);
    }
}