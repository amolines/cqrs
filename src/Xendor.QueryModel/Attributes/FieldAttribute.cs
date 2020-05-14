using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xendor.QueryModel.Extensions.Collections.Generic;
using Xendor.QueryModel.Extensions.Reflection;

namespace Xendor.QueryModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string name, bool fullTextSearch = false)
        {
            Name = name;
            FullTextSearch = fullTextSearch;
        }

        public string Name { get; }
        public bool FullTextSearch { get; }
        public static  Dictionary<string, Type> GetFields<T>(bool onlyFullTextSearch = false)
        {
            var fields = GetFields(typeof(T), k=>k.Name, onlyFullTextSearch);
            var deepFields = typeof(T).GetProperties<DeepFieldAttribute>();
            foreach (var deepField in deepFields)
            {
                var name = deepField.GetCustomAttribute<DeepFieldAttribute>().Name;
                fields.TryAddRange(GetFields(name, deepField.PropertyType, onlyFullTextSearch));
            }
            return fields;
        }
        private static Dictionary<string, Type> GetFields(Type type, Func<FieldAttribute, string> keySelector, bool onlyFullTextSearch)
        {
            Dictionary<string, Type> fields;
            if (onlyFullTextSearch)
            {
                fields = type.GetProperties<FieldAttribute>(k => k.FullTextSearch)
                    .ToDictionary(k => keySelector(k.GetCustomAttribute<FieldAttribute>()), v => v.PropertyType);
            }
            else
            {
                fields = type.GetProperties<FieldAttribute>()
                    .ToDictionary(k => keySelector(k.GetCustomAttribute<FieldAttribute>()), v => v.PropertyType);
            }

            return fields;
        }
        private static Dictionary<string, Type> GetFields(string name, Type type, bool onlyFullTextSearch = false)
        {
            var fields = GetFields(type , k => $"{name}.{k.Name}", onlyFullTextSearch);
            var deepFields = type.GetProperties<DeepFieldAttribute>();
            foreach (var deepField in deepFields)
            {
                var newName = $"{name}.{deepField.GetCustomAttribute<DeepFieldAttribute>().Name}";
                fields.TryAddRange(GetFields(newName, deepField.ReflectedType));
            }

            return fields;
        }
    }
}