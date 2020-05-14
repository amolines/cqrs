using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class LongConvert : Convert<long>
    {
        protected override long ToConvert(string value)
        {
            if (!long.TryParse(value,out   var result))
            {
                throw new InvalidCastConvertException(value, typeof(long));
            }
            return result;
        }
    }
}