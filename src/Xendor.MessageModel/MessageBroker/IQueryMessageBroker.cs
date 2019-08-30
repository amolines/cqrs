using Xendor.MessageBroker;
using Xendor.ServiceLocator;

namespace Xendor.MessageModel.MessageBroker
{
    public interface IQueryMessageBroker : ISingletonLifestyle , IMessageBroker
    {
        void Bind<TFilter>()
            where TFilter : IQueryMessageFilter, new();

       
    }
}