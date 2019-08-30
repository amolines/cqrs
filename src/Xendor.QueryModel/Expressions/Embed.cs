using System;

namespace Xendor.QueryModel.Expressions
{
    public class Embed
    {
        public Embed(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get;  }
        public Type Type { get; }

    }
}