using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Expressions.OperatorCollection
{
    public interface IOperatorCollectionExpression : IExpression
    {
        IEnumerable<Operator> Operators { get; }
        void Add(string name, string value, Type type, Operators operators);

    }
}