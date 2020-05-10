using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.OrderBy
{
    public interface IOrderByExpression : IExpression

    {
        IEnumerable<Field> Fields { get; }
    }
}