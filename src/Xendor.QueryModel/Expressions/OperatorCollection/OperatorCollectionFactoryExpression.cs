using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Xendor.QueryModel.Expressions.FilterCollection;

namespace Xendor.QueryModel.Expressions.OperatorCollection
{
    internal class OperatorCollectionFactoryExpression<TMetaData> : FactoryExpression<TMetaData, IOperatorCollectionExpression>
        where TMetaData : IMetaDataExpression


    {
        public OperatorCollectionFactoryExpression(IQueryCollection queryCollection)
            : base(queryCollection)
        {
        }

        protected override bool Contains()
        {
            return Keys.Any(k => !k.StartsWith("_") && k.Contains("_"));
        }

        protected override bool Validate()
        {
            var fields = Cache.GetFields<TMetaData>().Keys;
            var filters = Keys
                .Where(k => !k.StartsWith("_") && k.Contains("_"))
                .Select(f => f.Split('_')[0]).Distinct()
                .ToArray();
            return filters.Distinct().Intersect(fields).Count().Equals(filters.Distinct().Count());
        }

        protected override IOperatorCollectionExpression Extract()
        {
            var fields = Cache.GetFields<TMetaData>();
            var operators = new List<Operator>();
            var keys = Keys.Where(k => !k.StartsWith("_") && k.Contains("_")).Distinct();
            foreach (var key in keys)
            {
                var values = GetValue(key);
                foreach (var v in values)
                {
                    var name = key.Split('_')[0];
                    var value = v;
                    var type = fields[name];

                    Operators ope;
                    switch (key.Split('_')[1])
                    {
                        case "gt":
                            ope = Operators.GreaterThat;
                            break;
                        case "lt":
                            ope = Operators.LessThat;
                            break;
                        case "gte":
                            ope = Operators.GreaterThatOrEqual;
                            break;
                        case "lte":
                            ope = Operators.LessThatOrEqual;
                            break;
                        case "like":
                            ope = Operators.Like;
                            break;
                        default:
                            ope = Operators.Distinct;
                            break;
                    }

                    operators.Add(new Operator(name, value, type, ope));
                }

            }
            return new OperatorCollectionExpression<TMetaData>(operators);
        }
    }
}