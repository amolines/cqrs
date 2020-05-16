using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class AccountActivateQueryMessageFilter : QueryMessageFilter<AccountActivateQueryDataMapper>
    {
        public AccountActivateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "account.activated", ArgumentType.String));
        }
    }
}