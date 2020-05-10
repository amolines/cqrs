using System;

namespace Xendor.QueryModel.Criteria.Converts
{
    public interface IConvert
    {
        object Parse(Type type, string value);
        object Parse<T>(string value);
    }
}