using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.FilterCollection
{
    public class FilterCollectionExpression<TMetaData> : IFilterCollectionExpression
        where TMetaData : IMetaDataExpression
    {
        private readonly List<Filter> _filter;

        internal FilterCollectionExpression(IEnumerable<Filter> filter)
        {
            _filter = new List<Filter>();
            _filter.AddRange(filter);
        }
        public static IFilterCollectionExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new FilterCollectionFactoryExpression<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<Filter> Filters => _filter.AsReadOnly();
        public override string ToString()
        {
            var filters = string.Join("&" , _filter.Select(f => $"{f.Name}={f.Value}"));
            return filters;
        }

        public void Add(string name, string value, Type type)
        {
            _filter.Add(new Filter(name, value, type));
        }
    }
}