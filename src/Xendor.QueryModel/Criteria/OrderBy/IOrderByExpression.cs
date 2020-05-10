using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.OrderBy
{
    public interface IOrderByExpression<TMetaData> : IExpression<TMetaData>
        where TMetaData : IMetaDataExpression
    {
        IEnumerable<Field> Fields { get; }
    }
}