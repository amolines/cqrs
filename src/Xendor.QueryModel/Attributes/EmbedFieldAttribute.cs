using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.QueryModel.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EmbedFieldAttribute : Attribute
    {
        public EmbedFieldAttribute(string name)
        {
            Name = name;

        }

        public string Name { get; }


        public static IEnumerable<string> GetFields<T>()
        {
            var fields = typeof(T).GetCustomAttributes<EmbedFieldAttribute>();
            return fields.Select(field => field.Name);
        }

    }
}