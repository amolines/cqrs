using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class ClientUpdateQueryMessageFilter : QueryMessageFilter<ClientUpdateQueryDataMapper>
    {
        public ClientUpdateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "client.updated", ArgumentType.String));
        }
    }
}