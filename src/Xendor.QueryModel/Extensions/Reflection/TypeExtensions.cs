using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.QueryModel.Extensions.Reflection
{

    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetProperties<T>(this Type type)
            where T : Attribute
        {
            return type
                .GetProperties()
                .Where(p => CustomAttributeExtensions.GetCustomAttributes<T>((MemberInfo)p).Any());
        }
        public static IEnumerable<PropertyInfo> GetProperties<T>(this Type type, Func<T, bool> predicate)
            where T : Attribute
        {
            return type.GetProperties<T>()
                .Where(p=> predicate(p.GetCustomAttribute<T>()));
        }
    }
}
