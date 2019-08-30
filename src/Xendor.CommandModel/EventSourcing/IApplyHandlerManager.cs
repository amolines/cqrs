using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing
{
    public interface IApplyHandlerManager
    {
        void Invoke(Event @event);
    }
}