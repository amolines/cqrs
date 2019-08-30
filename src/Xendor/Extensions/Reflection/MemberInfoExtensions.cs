using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.Extensions.Reflection
{

    public static class MemberInfoExtensions
    {
        public static List<TAttribute> GetAttributesOfMemberAndDeclaringType<TAttribute>(this MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            var attributeList = new List<TAttribute>();

            //Add attributes on the member
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            //Add attributes on the class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            return attributeList;
        }
        public static T GetSingleAttributeOrNull<T>(this MemberInfo memberInfo, bool inherit = true) 
            where T : class
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            var attrs = memberInfo.GetCustomAttributes(typeof(T), inherit);
            if (attrs.Length > 0)
            {
                return (T)attrs[0];
            }

            return default(T);
        }


       
    }
}
