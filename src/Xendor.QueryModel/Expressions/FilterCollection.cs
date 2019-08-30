using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xendor.QueryModel.Expressions
{
    public class FilterCollection
    {
        private readonly List<Filter> _filter;

        public FilterCollection()
        {
            _filter = new List<Filter>();
        }

        internal void Add(string name, string value, Type type)
        {
            var filter = new Filter(name, value, type);
            _filter.Add(filter);
        }
        public IEnumerable<Filter> Filters => new ReadOnlyCollection<Filter>(_filter);
        public override string ToString()
        {
            var filters = string.Join("&" , _filter.Select(f => $"{f.Name}={f.Value}"));
            return filters;
        }

        public bool Any()
        {
            return _filter.Any();
        }
    }
}