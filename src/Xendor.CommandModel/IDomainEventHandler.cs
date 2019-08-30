using System.Threading.Tasks;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel
{
    public interface IDomainEventHandler<in T> : ITransientLifestyle
       where T : Event
    {
        Task HandleAsync(T @event);
    }
}
