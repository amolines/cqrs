using System;

namespace Xendor.QueryModel.Expressions.Converts
{
    internal abstract class FilterConvert<TOut> : IFilterConvert
    {
        public object Parse(string value)
        {
            return ToConvert(value);
        }

        public Type Type => typeof(TOut);
        protected abstract TOut ToConvert(string value);
    }
}