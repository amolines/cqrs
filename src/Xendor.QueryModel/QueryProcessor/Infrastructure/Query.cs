using System.Collections.Generic;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public abstract class Query : IQuery
    {
        protected Query() { }

        protected Query(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }

        public IDictionary<string, object> Parameters { get; }
        public abstract string Sql { get; }

        public abstract void SetCriteria(ICriteria criteria);

        public abstract IQuery SqlCount { get; }

    }
}