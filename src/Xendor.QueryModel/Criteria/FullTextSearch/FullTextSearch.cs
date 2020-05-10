using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public  class FullTextSearch<TMetaData> : IFullTextSearch<TMetaData>
        where TMetaData : IMetaDataCriteria
    {
        private readonly List<string> _names;
        internal FullTextSearch(List<string> names, string value)
        {
            _names = names;
            Value = value;
        }
        public static IFullTextSearch<TMetaData> Extract(IQueryCollection queryCollection)
        {
            var factory = new FullTextSearchFactory<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<string> Name => new ReadOnlyCollection<string>(_names);
        public string Value { get; }
        public override string ToString()
        {
            return $"q={Value}";
        }
    }
}