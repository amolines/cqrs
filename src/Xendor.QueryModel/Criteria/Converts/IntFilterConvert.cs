

using Xendor.QueryModel.Criteria.Converts.Exceptions;

namespace Xendor.QueryModel.Criteria.Converts
{
    internal class IntFilterConvert : FilterConvert<int>
    {
        protected override int ToConvert(string value)
        {
            if (!int.TryParse(value, out var result))
            {
                throw new FilterConvertException(value, typeof(int));
            }
            return result;
        }
    }
}