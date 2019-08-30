using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.QueryModel.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EmbedFieldAttribute : Attribute
    {
        public EmbedFieldAttribute(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public Type Type { get; }

        public static Dictionary<string, Type> GetFields<T>()
        {
            var fields = typeof(T).GetCustomAttributes<EmbedFieldAttribute>();
            return fields.ToDictionary(field => field.Name, field => field.Type);
        }

    }
}