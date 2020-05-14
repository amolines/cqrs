using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.OrderBy
{
    internal class OrderByFactoryExpression<TMetaData> : FactoryExpression<TMetaData, IOrderByExpression>
        where TMetaData : IMetaDataExpression


    {
        public OrderByFactoryExpression(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return ContainsKey(OrderByReservedWords.KeyOrder) && ContainsKey(OrderByReservedWords.KeySort);
        }

        protected override bool Validate()
        {
            var isValid = false;

            var order = GetValue(OrderByReservedWords.KeyOrder);
            var sort = GetValue(OrderByReservedWords.KeySort);

            if (!order.Length.Equals(1) || !sort.Length.Equals(1)) return false;
            var sortValue = sort[0].Split(',');
            if (sortValue.Intersect(Cache.GetFields<TMetaData>().Keys).Count().Equals(sortValue.Count()))
            {
                isValid = true;
            }


            return isValid;
        }

        protected override IOrderByExpression Extract()
        {
            var fields = new List<Field>();

            var order = GetValue(OrderByReservedWords.KeyOrder)[0];
            var sort = GetValue(OrderByReservedWords.KeySort)[0];


            var sortValue = sort.Split(',');
            var orderValue = order.Split(',');

            var index = 0;
            foreach (var value in sortValue)
            {
                var field = orderValue[index].Equals("asc") ? new Field(value, Order.Asc) : new Field(value, Order.Desc);
                index++;
                fields.Add(field);
            }
            return new OrderByExpression<TMetaData>(fields);
        }
    }
}