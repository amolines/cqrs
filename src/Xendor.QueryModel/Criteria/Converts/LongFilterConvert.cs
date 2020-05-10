

using Xendor.QueryModel.Criteria.Converts.Exceptions;

namespace Xendor.QueryModel.Criteria.Converts
{
    internal class LongFilterConvert : FilterConvert<long>
    {
        protected override long ToConvert(string value)
        {
            if (!long.TryParse(value, out var result))
            {
                throw new FilterConvertException(value, typeof(long));
            }
            return result;
        }
    }
}