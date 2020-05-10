using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria.OrderBy
{
    public class OrderByExpression<TMetaData> : IOrderByExpression
        where TMetaData : IMetaDataExpression
    {
        private readonly IList<Field> _fields;
        internal OrderByExpression(IEnumerable<Field> fields)
        {
            _fields = new List<Field>(fields);
        }
        public static IOrderByExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new OrderByFactoryExpression<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<Field> Fields => new ReadOnlyCollection<Field>(_fields);
        public override string ToString()
        {
            var sort = string.Join(",", _fields.Select(p => p.Property));
            var order = string.Join(",", _fields.Select(p => p.Order.ToString().ToLower()));
            return $"_sort={sort}&_order={order}";
        }
    }
}