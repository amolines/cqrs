using System.Collections.Generic;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.ProductAggregate.Entities
{
    public class ClientCollection : EntityCollection<Client>
    {
        public ClientCollection()
        { }
        public ClientCollection(IEnumerable<Client> entities)
            : base(entities)
        { }
     

    }
}