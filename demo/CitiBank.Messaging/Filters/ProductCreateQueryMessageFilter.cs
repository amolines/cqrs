using CitiBank.Messaging.Filters.DataMappers;
using Xendor.MessageBroker;
using Xendor.MessageModel.MessageBroker;

namespace CitiBank.Messaging.Filters
{
    public class ProductCreateQueryMessageFilter : QueryMessageFilter<ProductCreateQueryDataMapper>
    {
        public ProductCreateQueryMessageFilter()
        {
            Binding.AddArgument(new Argument("contentType", "product.created", ArgumentType.String));
        }
    }
}
