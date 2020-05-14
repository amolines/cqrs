

using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class IntConvert : Convert<int>
    {
        protected override int ToConvert(string value)
        {
            if (!int.TryParse(value, out var result))
            {
                throw new InvalidCastConvertException(value, typeof(int));
            }
            return result;
        }
    }
}