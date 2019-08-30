using Xendor.QueryModel.Expressions.Converts.Exceptions;

namespace Xendor.QueryModel.Expressions.Converts
{
    internal class DoubleFilterConvert : FilterConvert<double>
    {
        protected override double ToConvert(string value)
        {
            if (!double.TryParse(value, out var result))
            {
                throw new FilterConvertException(value, typeof(double));
            }
            return result;
        }
    }
}