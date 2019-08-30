using System;

namespace Xendor.QueryModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HeaderNameAttribute : Attribute
    {
        public HeaderNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}