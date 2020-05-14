using System;
using System.Linq;
using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    internal class DateTimeConvert : Convert<DateTime>
    {
        protected override DateTime ToConvert(string value)
        {
            return Convert(value);
        }

        private DateTime Convert(string value)
        {
            if (!value.Length.Equals(8)) throw new InvalidCastConvertException(value, typeof(DateTime));
            if (value.Select(char.IsDigit).Count() < 8) throw new InvalidCastConvertException(value, typeof(DateTime));

            DateTime result;
            var year = int.Parse(value.Substring(0, 4));
            var month = int.Parse(value.Substring(4, 2));
            var day = int.Parse(value.Substring(6, 2));
            try
            {
                result = new DateTime(year, month, day);
            }
            catch
            {
                throw new InvalidCastConvertException(value, typeof(DateTime));
            }

            return result;
        }
    }
}