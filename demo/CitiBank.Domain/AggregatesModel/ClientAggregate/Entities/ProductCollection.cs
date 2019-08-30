using System;
using System.Collections.Generic;
using System.Linq;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.ClientAggregate.Entities
{
    public class ProductCollection : EntityCollection<Product>
    {
        public ProductCollection()
        { }
        public ProductCollection(IEnumerable<Product> entities)
            : base(entities)
        { }
        public override bool CanAdd(Product entity)
        {
            var result = !Entities.Any(p => p.Id.Equals(entity.Id) );
            return result;
        }
     
        public bool Exists(Guid id)
        {
            return Exists(p => p.Id.Equals(id));
        }

    }
}