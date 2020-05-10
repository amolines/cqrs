using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.OrderBy
{
    public class OrderByEmpty<TMetaData> : IOrderBy<TMetaData>
        where TMetaData : IMetaDataCriteria
    {
        public IEnumerable<Field> Fields => new List<Field>().AsReadOnly();
    }
}