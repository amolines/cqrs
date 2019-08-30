using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xendor.CommandModel.EventSourcing.SnapShotting
{
    public abstract class Snapshot
    {
        [InternalProperty]
        public string ContentType
        {
            get
            {
                var contentTypeAttribute = GetType().GetCustomAttribute<ContentTypeAttribute>();
                return contentTypeAttribute.Name;
            }
        }
        [InternalProperty]
        public IDictionary<string, object> Payload
        {
            get
            {
                IDictionary<string, object> values = new Dictionary<string, object>();
                foreach (var property in Properties())
                {
                    var value = property.GetValue(this);
                    if (value != null)
                        values.Add(property.Name, property.GetValue(this));
                }
                return values;
            }
        }
        private IEnumerable<PropertyInfo> Properties()
        {
            return GetType().GetProperties().Where(p => !p.GetCustomAttributes<InternalPropertyAttribute>().Any()).ToArray();
        }
        [InternalProperty]
        public long Id { get; internal set; }
        [InternalProperty]
        public Guid AggregateId { get; internal set; }
        [InternalProperty]
        public int Version { get; set; }
    }
}
