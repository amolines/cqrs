using System;
using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate.Events
{

    [ContentType("product.client.subscribed")]
    public class ClientSubscribedEvent : Event
    {
        public ClientSubscribedEvent(Guid clientId , string fullName, string email)
        {
            ClientId = clientId;
            FullName = fullName;
            Email = email;
        }
        public Guid ClientId { get; }
        public string FullName { get; }

        public string Email { get; }

    }
}