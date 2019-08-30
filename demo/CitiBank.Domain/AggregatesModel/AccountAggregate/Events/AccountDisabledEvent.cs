using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Events
{
    [ContentType("account.disabled")]
    public class AccountDisabledEvent : Event
    {
        public AccountDisabledEvent()
        {

        }
    }
}