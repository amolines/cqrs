using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class ClientCreateQueryMessageFilter : QueryMessageFilter<ClientCreateQueryDataMapper>
    {
        public ClientCreateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "client.created", ArgumentType.String));
        }
    }
}