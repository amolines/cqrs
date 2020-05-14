using System.Collections.Generic;

namespace Xendor.QueryModel.Expressions.FullTextSearch
{
    public interface IFullTextSearchExpression: IExpression

    {
        IEnumerable<string> Name {get; }
        string Value { get; }
    }
}