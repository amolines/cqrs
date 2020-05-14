using System;

namespace Xendor.QueryModel.Converts
{
    public interface IConvert
    {
        object Parse(string value);

        Type Type { get; }
    }
}
