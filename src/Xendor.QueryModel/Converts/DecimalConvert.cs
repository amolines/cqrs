

using System.Globalization;
using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class DecimalConvert : Convert<decimal>
    {
        protected override decimal ToConvert(string value)
        {
            if (!decimal.TryParse(value,NumberStyles.Any,new CultureInfo("en-US"),out  var result))
            {
                throw new InvalidCastConvertException(value, typeof(decimal));
            }
            return result;
        }
    }
}