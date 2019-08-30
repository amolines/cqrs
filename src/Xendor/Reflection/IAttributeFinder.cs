using System;
using System.Reflection;
using Xendor.ServiceLocator;

namespace Xendor.Reflection
{
   
    public interface IAttributeFinder : ISingletonLifestyle
    {
              T GetAttributeOrNull<T>(MemberInfo methodInfo) 
            where T : Attribute;

          T GetAttributeOrNull<T>(Type type)
            where T : Attribute;

         T GetAttributeOrNull<T>(Type type, MemberInfo methodInfo)
            where T : Attribute;
    }
}