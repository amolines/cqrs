using System;

namespace Xendor.QueryModel.Converts.Exceptions
{
    public class InvalidCastConvertException : Exception
    {
        public InvalidCastConvertException(string value, Type convertType ) : 
            base($"The value [{value}] cannot be converted to type [{convertType.Name}]")
        {
        }
    }
}