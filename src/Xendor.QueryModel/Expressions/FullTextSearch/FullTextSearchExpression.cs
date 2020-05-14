using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.FullTextSearch
{
    public  class FullTextSearchExpression<TMetaData> : IFullTextSearchExpression
        where TMetaData : IMetaDataExpression
    {
        private readonly List<string> _names;
        internal FullTextSearchExpression(List<string> names, string value)
        {
            _names = names;
            Value = value;
        }
        public static IFullTextSearchExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new FullTextSearchFactoryExpression<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<string> Name => new ReadOnlyCollection<string>(_names);
        public string Value { get; }
        public override string ToString()
        {
            return $"_q={Value}";
        }
    }
}