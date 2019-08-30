using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.Converts;
namespace Xendor.QueryModel.MySql
{
    internal class Where
    {

        private readonly string _where;
        private IDictionary<string, object> _parameters;
        public Where(IEnumerable<Filter> filters)
        {
            _parameters = new Dictionary<string, object>();
            var _convert = new Convert();

            var @where = new List<string>();
            var count = 1;
            foreach (var filter in filters.GroupBy(g => g.Name))
            {
                if (filter.Count() > 1)
                {
                    var parameterIn = new List<string>();
                    foreach (var f in filter)
                    {
                        var value = _convert.Parse(f.Type, f.Value);
                        _parameters.Add($"@p{count}", value);
                        parameterIn.Add($"@p{count}");
                        count++;
                    }
                    @where.Add($"`{filter.Key}` in ({string.Join(",", parameterIn)})");
                }
                else
                {
                    @where.Add($"`{filter.Key}` = @p{count}");
                    var value = _convert.Parse(filter.First().Type, filter.First().Value);
                    _parameters.Add($"@p{count}", value);
                    count++;
                }
            }
            _where = string.Join(" AND ", @where);

        }
        public void AddParameters(IDictionary<string, object> parameters)
        {
            foreach (var parameter in _parameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }

        }

        public string Sql => _where;
    }
}