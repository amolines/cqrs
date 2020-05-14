using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.FullTextSearch
{
    internal class FullTextSearchFactoryExpression<TMetaData> : FactoryExpression<TMetaData, IFullTextSearchExpression>
        where TMetaData : IMetaDataExpression
    {
        public FullTextSearchFactoryExpression(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return ContainsKey(FullTextSearchReservedWords.KeyQ);
        }

        protected override bool Validate()
        {
            var fullTextSearch = GetValue(FullTextSearchReservedWords.KeyQ);
            return fullTextSearch.Length.Equals(1);
        }

        protected override IFullTextSearchExpression Extract()
        {
            var value = GetValue(FullTextSearchReservedWords.KeyQ)[0];
            return new FullTextSearchExpression<TMetaData>(Cache.GetFullTextSearchFields<TMetaData>().Keys.ToList(), value);
        }
    }
}