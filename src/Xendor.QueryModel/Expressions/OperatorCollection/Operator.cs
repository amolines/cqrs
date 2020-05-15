using System;

namespace Xendor.QueryModel.Expressions.OperatorCollection
{
    public class Operator
    {
        public Operator(string name, string value, Type type, Operators operators)
        {
            Name = name;
            Value = value;
            Type = type;
            Operators = operators;
        }

        public string Name { get;  }
        public string Value { get; }
        public Type Type { get; }
        public Operators Operators { get; }
        public override string ToString()
        {
            switch (Operators)
            {
                case Operators.GreaterThat:
                    return $"{Name}_gt={Value}";
                case Operators.LessThat:
                    return $"{Name}_lt={Value}";
                case Operators.GreaterThatOrEqual:
                    return $"{Name}_gte={Value}";
                case Operators.LessThatOrEqual:
                    return $"{Name}_lte={Value}";
                case Operators.Like:
                    return $"{Name}_like={Value}";
                case Operators.Distinct:
                    return $"{Name}_ne={Value}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}