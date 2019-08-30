using Xendor.Data;
using Xendor.MessageBroker;

namespace Xendor.MessageModel.MessageBroker
{
    public interface IQueryMessageFilter : IMessageFilter<IQuery>
    {

    }
}