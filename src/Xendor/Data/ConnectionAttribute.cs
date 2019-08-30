using System;

namespace Xendor.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConnectionAttribute : Attribute
    {
        public ConnectionAttribute(string property)
        {
            Property = property;
        }

        public string Property { get; }
    }
}