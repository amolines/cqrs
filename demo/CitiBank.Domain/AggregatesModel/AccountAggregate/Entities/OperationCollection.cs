using System.Collections.Generic;
using Xendor.CommandModel;

namespace CitiBank.Domain.AggregatesModel.AccountAggregate.Entities
{
    public class OperationCollection : EntityCollection<Operation>
    {
        public OperationCollection()
        { }
        public OperationCollection(IEnumerable<Operation> entities)
            : base(entities)
        { }
     

    }
}