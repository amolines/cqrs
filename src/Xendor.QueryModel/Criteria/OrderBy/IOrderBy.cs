using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.OrderBy
{
    public interface IOrderBy<TMetaData> : ICriteria<TMetaData>
        where TMetaData : IMetaDataCriteria
    {
        IEnumerable<Field> Fields { get; }
    }
}