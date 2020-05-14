using System;

namespace Xendor.QueryModel.Expressions.FilterCollection
{
    public class Filter
    {
        public  Filter(string name, string value, Type type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string Name { get;  }
        public string Value { get; }
        public Type Type { get; }
        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}