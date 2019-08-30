using System;

namespace Xendor.QueryModel.Expressions.Converts
{
    internal interface IFilterConvert
    {
        object Parse(string value);

        Type Type { get; }
    }
}
