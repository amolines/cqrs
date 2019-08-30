using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xendor.QueryModel.Expressions
{
    public class Sort
    {
        private readonly IList<Field> _fields;
        public Sort(IEnumerable<Field> fields)
        {
            _fields = new List<Field>(fields);
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