using System;

namespace Xendor.QueryModel.Criteria.Converts.Exceptions
{
    public class FilterConvertException : Exception
    {
        public FilterConvertException(string value, Type converType ) : 
            base($"The value [{value}] cannot be converted to type [{converType.Name}]")
        {
        }
    }
}