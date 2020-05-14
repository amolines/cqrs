using System;
using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class GuidConvert : Convert<Guid>
    {
        protected override Guid ToConvert(string value)
        {
            if (!Guid.TryParse(value, out var result))
            {
                throw new InvalidCastConvertException(value, typeof(Guid));
            }
            return result;
        }
    }
}