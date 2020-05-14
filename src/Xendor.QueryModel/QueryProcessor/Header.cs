using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.QueryProcessor
{
    public class Header
    {
        public  IDictionary<string,string> Value
        {
            get
            {
                var values = new Dictionary<string, string>();
                var properties = Properties();
                foreach (var property in properties)
                {
                    var key = property.GetCustomAttribute<HeaderNameAttribute>().Name;
                    var value = property.GetValue(this);

                    values.Add(key, value.ToString());
                }
                return values;
            }
          
        }
        private IEnumerable<PropertyInfo> Properties()
        {
            return GetType().GetProperties().Where(p => CustomAttributeExtensions.GetCustomAttributes<HeaderNameAttribute>((MemberInfo)p).Any());
        }
    }
}