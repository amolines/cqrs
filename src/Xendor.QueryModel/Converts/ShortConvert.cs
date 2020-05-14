using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class ShortConvert : Convert<short>
    {
        protected override short ToConvert(string value)
        {
            if (!short.TryParse(value, out var result))
            {
                throw new InvalidCastConvertException(value, typeof(short));
            }
            return result;
        }
    }
}