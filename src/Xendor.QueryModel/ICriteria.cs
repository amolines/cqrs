using System;
using System.Collections.Generic;
using Xendor.QueryModel.Criteria.FilterCollection;
using Xendor.QueryModel.Criteria.FullTextSearch;
using Xendor.QueryModel.Criteria.OrderBy;
using Xendor.QueryModel.Criteria.Paginate;
using Xendor.QueryModel.Criteria.Slice;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel
{
    public interface ICriteria
    {
        IPaginateExpression Paginate { get; }
        IOrderByExpression Sort { get; }
        EmbedCollection Embeds { get; }
        IFullTextSearchExpression FullTextSearch { get; }
        ISliceExpression Slice { get; }
        string Path { get; }
        IEnumerable<Filter> Filters { get; }
        bool IsPaginate { get; }
        bool IsSlice { get; }

        void AddFilter(string name, string value, Type type);
    }
}