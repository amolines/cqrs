using System;

namespace Xendor.QueryModel.Converts
{
    internal abstract class Convert<TOut> : IConvert
    {
        public object Parse(string value)
        {
            return ToConvert(value);
        }

        public Type Type => typeof(TOut);
        protected abstract TOut ToConvert(string value);
    }
}