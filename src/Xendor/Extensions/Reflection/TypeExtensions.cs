using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.Extensions.Reflection
{

    public static class TypeExtensions
    {


        public static string GetContentTypeName(this Type eventType)
        {
            var contentTypeAttribute = eventType.GetCustomAttribute<ContentTypeAttribute>();
            return contentTypeAttribute == null ? eventType.Name.ToLower() : contentTypeAttribute.Name;
        }
        public static bool IsAssignableToGenericType(this Type  givenType, Type genericType)
        {
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            if (givenType.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }

            if (givenType.BaseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(givenType.BaseType, genericType);
        }
        public static bool IsAssignableFrom<TInterface>(this Type type)
        {
            return typeof(TInterface).IsAssignableFrom(type);
        }
        public static Type CreateGenericType(this Type type, params Type[] args)
        {
            var genericType = type.MakeGenericType(type);
            return genericType;
        }
        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        public static bool IsSimpleOrNullableType(this Type type)
        {
            if (type.IsNullableType())
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return IsSimpleType(type);
        }
        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(Decimal) ||
                   type == typeof(DateTime) || type == typeof(Guid);
        }
        public static object GetDefault(this Type type)
        {
            if (type == null || !type.IsValueType || type == typeof(void))
                return null;

            if (type.ContainsGenericParameters)
                throw new ArgumentException(
                    "{" + MethodBase.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                    "> contains generic parameters, so the default value cannot be retrieved");

            if (!type.IsPrimitive && type.IsNotPublic)
                throw new ArgumentException("{" + MethodBase.GetCurrentMethod() +
                                            "} Error:\n\nThe supplied value type <" + type +
                                            "> is not a publicly-visible type, so the default value cannot be retrieved");
            try
            {
                return Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException(
                    "{" + MethodBase.GetCurrentMethod() + "} Error:\n\nThe Activator.CreateInstance method could not " +
                    "create a default instance of the supplied value type <" + type +
                    "> (Inner Exception message: \"" + e.Message + "\")", e);
            }


        }
        public static bool IsObjectSetToDefault(this Type ObjectType, object ObjectValue)
        {
            if (ObjectType == null)
            {
                if (ObjectValue == null)
                {
                    var currmethod = MethodBase.GetCurrentMethod();
                    var ExceptionMsgPrefix = currmethod.DeclaringType + " {" + currmethod + "} Error:\n\n";
                    throw new ArgumentNullException(ExceptionMsgPrefix +
                                                    "Cannot determine the ObjectType from a null Value");
                }

                ObjectType = ObjectValue.GetType();
            }

            var Default = ObjectType.GetDefault();
            if (ObjectValue != null)
                return ObjectValue.Equals(Default);
            return Default == null;
        }

    }
}
