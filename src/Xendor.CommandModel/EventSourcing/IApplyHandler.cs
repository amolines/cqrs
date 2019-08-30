using Xendor.EventBus;

namespace Xendor.CommandModel.EventSourcing
{
    public interface IApplyHandler<in TEvent>  
        where TEvent : Event
    {
        void Handle(TEvent message);
    }
}
