using Xendor.MessageBroker;
using  Xendor.CommandModel.Command;
namespace Xendor.CommandModel.MessageBroker
{
    public interface ICommandMessageFilter : IMessageFilter<ICommand>
    {

    }
}