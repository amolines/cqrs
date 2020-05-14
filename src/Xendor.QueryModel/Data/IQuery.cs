using System.Collections.Generic;

namespace Xendor.QueryModel.Data
{
    public interface IQuery
    {
        IDictionary<string, object> Parameters { get; }
        string Sql { get; }

    }
}