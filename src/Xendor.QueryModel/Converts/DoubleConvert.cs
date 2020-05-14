

using System.Globalization;
using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{

    internal class DoubleConvert : Convert<double>
    {
        protected override double ToConvert(string value)
        {
            if (!double.TryParse(value,NumberStyles.Any, new CultureInfo("en-US"),out  var result))
            {
                throw new InvalidCastConvertException(value, typeof(double));
            }
            return result;
        }
    }
}