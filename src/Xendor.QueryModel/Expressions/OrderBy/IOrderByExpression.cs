using System.Collections.Generic;

namespace Xendor.QueryModel.Expressions.OrderBy
{
    public interface IOrderByExpression : IExpression

    {
        IEnumerable<Field> Fields { get; }
    }
}