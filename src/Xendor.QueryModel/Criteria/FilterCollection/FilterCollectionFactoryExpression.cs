using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Xendor.QueryModel.Criteria.FilterCollection
{
    internal class FilterCollectionFactoryExpression<TMetaData> : FactoryExpression<TMetaData, IFilterCollectionExpression, FilterCollectionEmptyExpression<TMetaData>>
        where TMetaData : IMetaDataExpression


    {
        public FilterCollectionFactoryExpression(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return Keys.Any(k => !k.StartsWith("_"));
        }

        protected override bool Validate()
        {
            var fields = Cache.GetFields<TMetaData>().Keys;
            var filters = Keys.Where(k => !k.StartsWith("_")).ToList();
            return filters.Distinct().Intersect(fields).Count().Equals(filters.Distinct().Count());
        }

        protected override IFilterCollectionExpression Extract()
        {
            var fields = Cache.GetFields<TMetaData>();
            var filters = new List<Filter>();
            var keys = Keys.Where(k => !k.StartsWith("_"));
            foreach (var key in keys)
            {

                var values = GetValue(key);
                foreach (var v in values)
                {
                    var name = key;
                    var value = v;
                    var type = fields[name];
                    filters.Add(new Filter(name, value, type));
                }
               
            }
            return new FilterCollectionExpression<TMetaData>(filters);
        }
    }
}