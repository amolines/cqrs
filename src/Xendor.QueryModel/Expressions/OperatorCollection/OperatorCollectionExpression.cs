using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions.OperatorCollection
{
    public class OperatorCollectionExpression<TMetaData> : IOperatorCollectionExpression
        where TMetaData : IMetaDataExpression
    {
        private readonly List<Operator> _operators;

        internal OperatorCollectionExpression(IEnumerable<Operator> operators)
        {
            _operators = new List<Operator>();
            _operators.AddRange(operators);
        }
        public static IOperatorCollectionExpression Extract(IQueryCollection queryCollection)
        {
            var factory = new OperatorCollectionFactoryExpression<TMetaData>(queryCollection);
            return factory.Create(queryCollection);
        }
        public IEnumerable<Operator> Operators => _operators.AsReadOnly();
        public override string ToString()
        {
            var filters = string.Join("&" , _operators.Select(f => f.ToString()));
            return filters;
        }

        public void Add(string name, string value, Type type, Operators operators)
        {
            _operators.Add(new Operator(name, value, type, operators));
        }
    }
}