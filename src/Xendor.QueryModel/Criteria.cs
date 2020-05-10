using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Xendor.QueryModel.Attributes;
using Xendor.QueryModel.Criteria;
using Xendor.QueryModel.Criteria.FilterCollection;
using Xendor.QueryModel.Criteria.FullTextSearch;
using Xendor.QueryModel.Criteria.OrderBy;
using Xendor.QueryModel.Criteria.Paginate;
using Xendor.QueryModel.Criteria.Slice;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.Extensions;

namespace Xendor.QueryModel
{
    public class Criteria<TIn> : ICriteria
        where TIn : IMetaDataExpression
    {
        private readonly IFilterCollectionExpression _filters;
        private readonly EmbedCollection _embedCollection;
        public Criteria(string path , IQueryCollection query)
        {


            Paginate = PaginateExpression.Extract(query);
            Slice = SliceExpression.Extract(query);
            FullTextSearch = FullTextSearchExpression<TIn>.Extract(query);
            Sort = OrderByExpression<TIn>.Extract(query);
            _filters = FilterCollectionExpression<TIn>.Extract(query);

            //    if (string.IsNullOrEmpty(expression))
            //        throw new ArgumentNullException(nameof(expression));
            //    if (string.IsNullOrEmpty(path))
            //        throw new ArgumentNullException(nameof(path));

            //    Path = path;
            //    var values = expression.Split('&').ToList();
            //    var fields = Fields;
            //    var embeds = EmbedFields;

            //    if (values.TryGetFullTextSearch(FullTextSearchFields, out var fullTextSearch))
            //        FullTextSearch = fullTextSearch;
            //    if (values.SortIsValid(fields.Keys) && values.TryGetSort(out var sort))
            //        Sort = sort;
            //    if (values.TryGetPaginate(out var paginate))
            //        Paginate = paginate;
            //    else
            //    {
            //        if (values.TryGetSlice(out var slice))
            //            Slice = slice;
            //    }
            //    _embedCollection =  values.SetEmbeds(embeds);
            //    _filters = values.FilterIsValid(fields.Keys) ? values.SetFilters(fields) : new FilterCollection();
        }
        public override string ToString()
        {
            var expression = new List<string>();
            if (!(_filters is FilterCollectionEmptyExpression<TIn>))
                expression.Add(_filters.ToString());
            if (!(Sort is OrderByEmptyExpression<TIn>))
                expression.Add(Sort.ToString());
            if (!(FullTextSearch is FullTextSearchEmptyExpression<TIn>))
                expression.Add(FullTextSearch.ToString());
            if (!(Paginate is PaginateEmptyExpression))
                expression.Add(Paginate.ToString());
            if (!(Slice is SliceEmptyExpression))
                expression.Add(Slice.ToString());
            return string.Join("&", expression);
        }
        public IPaginateExpression Paginate { get; }
        public IOrderByExpression Sort { get; }
        public EmbedCollection Embeds => _embedCollection;
        public IFullTextSearchExpression FullTextSearch { get; }
        public ISliceExpression Slice { get; }
        public string Path { get; }
        public IEnumerable<Filter> Filters => _filters.Filters;
        public bool IsPaginate => Paginate != null;
        public bool IsSlice => Slice != null;
        public void AddFilter(string name, string value, Type type)
        {
            _filters.Add(name,value,type);
        }
       

    }
}