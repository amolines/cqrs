using System.Collections.Generic;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public interface IQuery
    {
        IDictionary<string, object> Parameters { get; }
        string Sql { get; }
        void SetCriteria(ICriteria criteria);
        IQuery SqlCount { get; }

    }

}