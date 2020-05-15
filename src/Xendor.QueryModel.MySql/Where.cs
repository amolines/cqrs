using System;
using System.Collections.Generic;
using System.Linq;
using Xendor.QueryModel.Converts;
using Xendor.QueryModel.Expressions.FilterCollection;
using Xendor.QueryModel.Expressions.OperatorCollection;

namespace Xendor.QueryModel.MySql
{
    internal class Where
    {

        private readonly string _where;
        private IDictionary<string, object> _parameters;
        public Where(IEnumerable<Filter> filters, IEnumerable<Operator> operators)
        {
            _parameters = new Dictionary<string, object>();
            var convert = new ConvertFactory();

            var @where = new List<string>();
            var count = 1;
            foreach (var filter in filters.GroupBy(g => g.Name))
            {
                if (filter.Count() > 1)
                {
                    var parameterIn = new List<string>();
                    foreach (var f in filter)
                    {
                        var value = convert.Parse(f.Type, f.Value);
                        _parameters.Add($"@p{count}", value);
                        parameterIn.Add($"@p{count}");
                        count++;
                    }
                    @where.Add($"`{filter.Key}` in ({string.Join(",", parameterIn)})");
                }
                else
                {
                    @where.Add($"`{filter.Key}` = @p{count}");
                    var value = convert.Parse(filter.First().Type, filter.First().Value);
                    _parameters.Add($"@p{count}", value);
                    count++;
                }
            }


            foreach (var @operator in operators)
            {
                var value = convert.Parse(@operator.Type, @operator.Value);


                switch (@operator.Operators)
                {
                    case Operators.GreaterThat:
                        @where.Add($"`{@operator.Name }` > @p{count}");
                        break;
                    case Operators.LessThat:
                        @where.Add($"`{@operator.Name }` < @p{count}");
                        break;
                    case Operators.GreaterThatOrEqual:
                        @where.Add($"`{@operator.Name }` >= @p{count}");
                        break;
                    case Operators.LessThatOrEqual:
                        @where.Add($"`{@operator.Name }` <= @p{count}");
                        break;
                    case Operators.Like:
                        @where.Add($"`{@operator.Name }` LIKE @p{count}");
                        value = $"'%{value}%'";
                        break;
                    case Operators.Distinct:
                        @where.Add($"`{@operator.Name }` <> @p{count}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            

                _parameters.Add($"@p{count}", value);
                count++;

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