using Xendor.MessageBroker;
using Xendor.ServiceLocator;

namespace Xendor.CommandModel.MessageBroker
{
    public interface ICommandMessageBroker : ISingletonLifestyle, IMessageBroker
    {
        void Bind<TFilter>()
            where TFilter : ICommandMessageFilter, new();


    }
}