using System;

namespace Xendor.QueryModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DeepFieldAttribute : Attribute
    {
        public DeepFieldAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

    }
}