using System;
using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Events
{
    [ContentType("client.product.subscribed")]
    public class ProductSubscribedEvent : Event
    {
        public ProductSubscribedEvent(Guid productId, string number , Guid clientId)
        {

            ProductId = productId;
            ClientId = clientId;
            Number = number;

        }

        public Guid ProductId { get; }
        public Guid ClientId { get; }
        public string Number { get;  }

    }
}