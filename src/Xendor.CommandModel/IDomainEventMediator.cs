using System.Threading.Tasks;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    public interface IDomainEventMediator : ISingletonLifestyle
    {
        Task SendAsync(Event domainEvent);

    }
}
