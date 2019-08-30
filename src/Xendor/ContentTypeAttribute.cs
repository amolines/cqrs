using System;

namespace Xendor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ContentTypeAttribute : Attribute
    {
        public ContentTypeAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}