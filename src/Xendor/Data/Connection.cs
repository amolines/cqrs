using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Xendor.Data
{
    public class Connection : IConnection
    {
        public override string ToString()
        {
            var connectionString = new StringBuilder();
            var properties = Properties();
            var index = 1;
            foreach (var property in properties)
            {
                var key = property.GetCustomAttribute<ConnectionAttribute>().Property;
                var value = property.GetValue(this);

                connectionString.Append(index.Equals(properties.Count()) ? $"{key}={value}" : $"{key}={value};");
                index++;
            }
            return connectionString.ToString();
        }
        private IEnumerable<PropertyInfo> Properties()
        {
            return GetType().GetProperties().Where(p => CustomAttributeExtensions.GetCustomAttributes<ConnectionAttribute>((MemberInfo) p).Any()).ToArray();
        }
    }
}