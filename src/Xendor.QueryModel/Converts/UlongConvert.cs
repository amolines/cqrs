using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class UlongConvert : Convert<ulong>
    {
        protected override ulong ToConvert(string value)
        {
            if (!ulong.TryParse(value, out var result))
            {
                throw new InvalidCastConvertException(value, typeof(ulong));
            }
            return result;
        }
    }
}