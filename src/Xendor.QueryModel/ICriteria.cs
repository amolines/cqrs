using System;
using System.Collections.Generic;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel
{
    public interface ICriteria
    {
        Paginate Paginate { get; }
        Sort Sort { get; }
        EmbedCollection Embeds { get; }
        FullTextSearch FullTextSearch { get; }
        Slice Slice { get; }
        string Path { get; }
        IEnumerable<Filter> Filters { get; }
        bool IsPaginate { get; }
        bool IsSlice { get; }

        void AddFilter(string name, string value, Type type);
    }
}