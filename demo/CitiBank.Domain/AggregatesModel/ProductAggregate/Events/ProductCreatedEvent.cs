using Xendor;
using Xendor.EventBus;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate.Events
{
    [ContentType("product.created")]
    public class ProductCreatedEvent : Event
    {
        public ProductCreatedEvent(string name, ProductType productType)
        {

            Name = name;
            ProductType = productType;
        }

        public string Name { get; }

        public ProductType ProductType { get;  }

    }
}