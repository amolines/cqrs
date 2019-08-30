using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Events
{
    [ContentType("client.updated")]
    public class ClientUpdatedEvent : Event
    {
        public ClientUpdatedEvent(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}