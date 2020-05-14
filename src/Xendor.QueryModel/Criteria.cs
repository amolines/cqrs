using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.EmbedCollection;
using Xendor.QueryModel.Expressions.FilterCollection;
using Xendor.QueryModel.Expressions.FullTextSearch;
using Xendor.QueryModel.Expressions.OrderBy;
using Xendor.QueryModel.Expressions.Paginate;
using Xendor.QueryModel.Expressions.Slice;


namespace Xendor.QueryModel
{
    public class Criteria<TIn> : ICriteria
        where TIn : IMetaDataExpression
    {
        private readonly IFilterCollectionExpression _filters;
        private readonly IEmbedCollectionExpression _embedCollection;
        public Criteria(string path , IQueryCollection query)
        {
            Path = path;
            Paginate = PaginateExpression.Extract(query);
            Slice = SliceExpression.Extract(query);
            FullTextSearch = FullTextSearchExpression<TIn>.Extract(query);
            Sort = OrderByExpression<TIn>.Extract(query);
            _filters = FilterCollectionExpression<TIn>.Extract(query);
            _embedCollection = EmbedCollectionExpression<TIn>.Extract(query);
        }
        public override string ToString()
        {
            var expression = new List<string>();
            if (Filters != null && Filters.Filters.Any())
                expression.Add(_filters.ToString());
            if (Sort != null)
                expression.Add(Sort.ToString());
            if (FullTextSearch != null)
                expression.Add(FullTextSearch.ToString());
            if (Paginate != null)
                expression.Add(Paginate.ToString());
            if (Slice != null)
                expression.Add(Slice.ToString());
            return string.Join("&", expression);

        }
        public IPaginateExpression Paginate { get; }
        public IOrderByExpression Sort { get; }
        public IEmbedCollectionExpression Embeds => _embedCollection;
        public IFullTextSearchExpression FullTextSearch { get; }
        public ISliceExpression Slice { get; }
        public string Path { get; }
        public IFilterCollectionExpression Filters => _filters;
        public bool IsPaginate => Paginate != null;
        public bool IsSlice => Slice != null;
        public void AddFilter(string name, string value, Type type)
        {
            _filters.Add(name,value,type);
        }
       

    }
}