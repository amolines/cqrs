using Xendor.QueryModel.Expressions.Converts.Exceptions;

namespace Xendor.QueryModel.Expressions.Converts
{
    internal class DecimalFilterConvert : FilterConvert<decimal>
    {
        protected override decimal ToConvert(string value)
        {
            if (!decimal.TryParse(value, out var result))
            {
                throw new FilterConvertException(value, typeof(decimal));
            }
            return result;
        }
    }
}