using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Events
{



    [ContentType("account.activated")]
    public class AccountActivatedEvent : Event
    {
        public AccountActivatedEvent()
        {

        }
    }
}