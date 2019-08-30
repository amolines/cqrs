using System;
using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.Attributes;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.Extensions;

namespace Xendor.QueryModel
{
    public class Criteria<TIn> : ICriteria
        where TIn : class
    {
        private readonly FilterCollection _filters;
        private readonly EmbedCollection _embedCollection;
        public Criteria(string path , string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException(nameof(expression));
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            Path = path;
            var values = expression.Split('&').ToList();
            var fields = Fields;
            var embeds = EmbedFields;

            if (values.TryGetFullTextSearch(FullTextSearchFields, out var fullTextSearch))
                FullTextSearch = fullTextSearch;
            if (values.SortIsValid(fields.Keys) && values.TryGetSort(out var sort))
                Sort = sort;
            if (values.TryGetPaginate(out var paginate))
                Paginate = paginate;
            else
            {
                if (values.TryGetSlice(out var slice))
                    Slice = slice;
            }
            _embedCollection =  values.SetEmbeds(embeds);
            _filters = values.FilterIsValid(fields.Keys) ? values.SetFilters(fields) : new FilterCollection();
        }
        public override string ToString()
        {
            var expression = new List<string>();
            if(Filters != null && Filters.Any())
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
        public Paginate Paginate { get; }
        public Sort Sort { get; }
        public EmbedCollection Embeds => _embedCollection;
        public FullTextSearch FullTextSearch { get; }
        public Slice Slice { get; }
        public string Path { get; }
        public IEnumerable<Filter> Filters => _filters.Filters;
        public bool IsPaginate => Paginate != null;
        public bool IsSlice => Slice != null;
        public void AddFilter(string name, string value, Type type)
        {
            _filters.Add(name,value,type);
        }
        private IDictionary<string, Type> Fields
        {
            get
            {
                var fields = FieldAttribute.GetFields<TIn>();
                return fields;
            }

        }
        private IDictionary<string, Type> FullTextSearchFields
        {
            get
            {
                var fields = FieldAttribute.GetFields<TIn>(true);
                return fields;
            }

        }
        private IDictionary<string, Type> EmbedFields
        {
            get
            {
                var fields = EmbedFieldAttribute.GetFields<TIn>();
                return fields;
            }

        }

    }
}