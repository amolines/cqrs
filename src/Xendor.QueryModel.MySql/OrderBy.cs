using System.Linq;
using Xendor.QueryModel.Expressions.OrderBy;

namespace Xendor.QueryModel.MySql
{
    internal class OrderBy
    {
        public OrderBy(IOrderByExpression sort)
        {
            var orders = sort.Fields.Select(field => $" `{field.Property}` {field.Order} ").ToList();
            Sql = $" ORDER BY {string.Join(",", orders)}";
        }

        public string Sql { get; }
    }
}