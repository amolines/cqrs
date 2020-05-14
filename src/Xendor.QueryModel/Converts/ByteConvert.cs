using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class ByteConvert : Convert<byte>
    {
        protected override byte ToConvert(string value)
        {
            if (!byte.TryParse(value, out var result))
            {
                throw new InvalidCastConvertException(value, typeof(byte));
            }
            return result;
        }
    }
}