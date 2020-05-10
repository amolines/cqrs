using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public interface IFullTextSearchExpression: IExpression

    {
        IEnumerable<string> Name {get; }
        string Value { get; }
    }
}