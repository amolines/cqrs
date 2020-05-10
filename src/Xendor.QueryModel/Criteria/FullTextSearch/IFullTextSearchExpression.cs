using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public interface IFullTextSearchExpression<TMetaData> : IExpression<TMetaData>
        where TMetaData : IMetaDataExpression
    {
        IEnumerable<string> Name {get; }
        string Value { get; }
    }
}