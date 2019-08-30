using System;
using System.Reflection;

namespace Xendor.Reflection
{
    public class AttributeFinder : IAttributeFinder
    {
        public T GetAttributeOrNull<T>(MemberInfo methodInfo)
         where T : Attribute
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(T), false);
            if (attrs.Length > 0)
            {
                return (T)attrs[0];
            }
            return null;
        }
        public T GetAttributeOrNull<T>(Type type)
                    where T : Attribute
        {
            var typeName = "I" + type.Name;
            var typeInterface = type.GetInterface(typeName);

            if (typeInterface != null)
            {
                var attrs = typeInterface.GetCustomAttributes(typeof(T), true);
                if (attrs.Length > 0)
                {
                    return (T)attrs[0];
                }
            }
            else
            {
                var attrs = type.GetCustomAttributes(typeof(T), true);
                if (attrs.Length > 0)
                {
                    return (T)attrs[0];
                }
            }

            return null;
        }

        public T GetAttributeOrNull<T>(Type type, MemberInfo methodInfo)
              where T : Attribute
        {
            var attr = GetAttributeOrNull<T>(methodInfo) ?? GetAttributeOrNull<T>(type);
            return attr;
        }
    }
}
