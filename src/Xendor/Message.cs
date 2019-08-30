using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor
{
    public class Message
    {
        private string _contentType;
        private Dictionary<string, object> _payload;
        [InternalProperty]
        public string ContentType
        {
            get
            {
                var contentTypeAttribute = GetType().GetCustomAttribute<ContentTypeAttribute>();
                return contentTypeAttribute == null ? _contentType : contentTypeAttribute.Name;
            }
            internal set => _contentType = value;
        }
        [InternalProperty]
        public Dictionary<string, object> Payload
        {
            get
            {

                if(_payload != null && _payload.Any())
                {
                    return _payload;
                }

                var values = new Dictionary<string, object>();
                foreach (var property in Properties())
                {
                    var value = property.GetValue(this);
                    if (value != null)
                        values.Add(property.Name, property.GetValue(this));
                }
                return values;

            }
            internal set => _payload = value;
        }
        private IEnumerable<PropertyInfo> Properties()
        {
            return GetType().GetProperties().Where(p => !CustomAttributeExtensions.GetCustomAttributes<InternalPropertyAttribute>((MemberInfo) p).Any()).ToArray();
        }
    }
}