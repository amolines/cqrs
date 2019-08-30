using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class AccountUpdateQueryMessageFilter : QueryMessageFilter<AccountUpdateQueryDataMapper>
    {
        public AccountUpdateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "account.changed", ArgumentType.String));
            Binding.AddArgument(new Argument("contentType", "account.transfer", ArgumentType.String));
        }
    }
}