using System.Collections.Generic;
using Xendor.EventBus;

namespace Xendor.Data
{
    public interface IQuery
    {
        IDictionary<string, object> Parameters { get; }
        string Sql { get; }

        Event Event { get; }
    }

}