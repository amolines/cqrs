using System;

namespace Xendor.QueryModel.Criteria.Converts
{
    internal interface IFilterConvert
    {
        object Parse(string value);

        Type Type { get; }
    }
}
