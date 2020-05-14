using System;

namespace Xendor.QueryModel.Converts
{
    public interface IConvertFactory
    {
        IConvert GetConvert(Type type);

        object Parse(Type type , string value);

    }
}