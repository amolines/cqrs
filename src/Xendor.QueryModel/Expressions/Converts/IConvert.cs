using System;

namespace Xendor.QueryModel.Expressions.Converts
{
    public interface IConvert
    {
        object Parse(Type type, string value);
        object Parse<T>(string value);
    }
}