using System;

namespace Xendor.QueryModel.Converts.Exceptions
{
    public class NotFoundConvertException : Exception
    {
        public NotFoundConvertException(Type convertType) :
            base($"The convert [{convertType.Name}] not found]")
        {
        }
    }
}