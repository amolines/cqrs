using System.Collections;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    public interface IDomainEventHandlerFactory : ISingletonLifestyle
    {
        IEnumerable CreateDomainEventHandler(Event domainEvent);
    }
}