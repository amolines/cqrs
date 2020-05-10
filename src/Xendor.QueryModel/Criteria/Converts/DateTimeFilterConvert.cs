using System;
using System.Linq;
using Xendor.QueryModel.Criteria.Converts.Exceptions;

namespace Xendor.QueryModel.Criteria.Converts
{
    internal class DateTimeFilterConvert : FilterConvert<DateTime>
    {
        protected override DateTime ToConvert(string value)
        {
            return Convert(value);
        }

        private DateTime Convert(string value)
        {
            if (!value.Length.Equals(8)) throw new FilterConvertException(value, typeof(DateTime));
            if (value.Select(char.IsDigit).Count() < 8) throw new FilterConvertException(value, typeof(DateTime));

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
                throw new FilterConvertException(value, typeof(DateTime));
            }

            return result;
        }
    }
}