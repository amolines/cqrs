using System;
using System.Collections.Generic;
using Xendor.QueryModel.Criteria.Converts.Factories;


namespace Xendor.QueryModel.Criteria.Converts
{
    public class Convert : IConvert
    {
        private readonly IDictionary<Type, IFilterConvertFactory> _converts;

        public Convert()
        {
            _converts = new Dictionary<Type, IFilterConvertFactory>();
            Init();
        }

        private void Init()
        {
            _converts.Add(typeof(string), new StringFilterConvertFactory());
            _converts.Add(typeof(int), new IntFilterConvertFactory());
            _converts.Add(typeof(double), new DoubleFilterConvertFactory());
            _converts.Add(typeof(long), new LongFilterConvertFactory());
            _converts.Add(typeof(Guid), new GuidFilterConvertFactory());
            _converts.Add(typeof(DateTime), new DateTimeFilterConvertFactory());
            _converts.Add(typeof(decimal), new DecimalFilterConvertFactory());
        }
        public object Parse(Type type, string value)
        {
            var convert = _converts[type].Create();
            return convert.Parse(value);
        }
        public object Parse<T>(string value)
        {
            return Parse(typeof(T) , value);
        }
    }
}