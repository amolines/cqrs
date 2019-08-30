using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendor.MessageBroker
{
    public interface IMessageBroker
    {
        Task HandleAsync(IEnvelope envelope);

        IEnumerable<string> GetFilter();
    }
}