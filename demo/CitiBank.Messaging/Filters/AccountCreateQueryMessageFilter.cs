using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class AccountCreateQueryMessageFilter : QueryMessageFilter<AccountCreateQueryDataMapper>
    {
        public AccountCreateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "account.created", ArgumentType.String));
        }
    }
}