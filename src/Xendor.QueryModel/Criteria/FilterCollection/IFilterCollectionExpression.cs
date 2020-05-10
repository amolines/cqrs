using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FilterCollection
{
    public interface IFilterCollectionExpression : IExpression
    {
        IEnumerable<Filter> Filters { get; }
        void Add(string name, string value, Type type);

    }
}