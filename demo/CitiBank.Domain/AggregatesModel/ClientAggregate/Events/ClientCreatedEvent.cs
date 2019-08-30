using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Events
{

    [ContentType("client.created")]
    public class ClientCreatedEvent : Event
    {
        public ClientCreatedEvent(string firstName, string lastName, string email)
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