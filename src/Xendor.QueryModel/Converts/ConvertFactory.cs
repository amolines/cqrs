using System;
using System.Collections.Generic;
using Xendor.QueryModel.Converts.Exceptions;

namespace Xendor.QueryModel.Converts
{
    public class ConvertFactory : IConvertFactory
    {
        private readonly IDictionary<Type, IConvert> _converts;

        public ConvertFactory()
        {
            _converts = new Dictionary<Type, IConvert>
            {
                {
                    typeof(string), new StringConvert()
                },
                {
                    typeof(byte), new ByteConvert()
                },
                {
                    typeof(short), new ShortConvert()
                },
                {
                    typeof(ulong), new UlongConvert()
                },
                {
                    typeof(DateTime), new DateTimeConvert()
                },
                {
                    typeof(decimal), new DecimalConvert()
                },
                {
                    typeof(double),new DoubleConvert()
                },
                {
                    typeof(Guid), new GuidConvert()
                },
                {
                    typeof(int), new IntConvert()
                },
                {
                    typeof(long), new LongConvert()
                }
            };
        }
        public IConvert GetConvert(Type type)
        {
            if (!_converts.ContainsKey(type)) throw new NotFoundConvertException(type);
            var convert = _converts[type];
            return convert;

        }

        public object Parse(Type type, string value)
        {
            var convert = GetConvert(type);
            return convert.Parse(value);
        }
    }
}