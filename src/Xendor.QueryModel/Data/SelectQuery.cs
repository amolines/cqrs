using System.Collections.Generic;
using Xendor.Data;

namespace Xendor.QueryModel.Data
{
    public abstract class SelectQuery : Query, ISelectQuery
    {
        protected SelectQuery() { }

        protected SelectQuery(IDictionary<string, object> parameters)
            : base(parameters)
        {

        }

        public abstract void SetCriteria(ICriteria criteria);

        public abstract IQuery SqlCount { get; }
    }
}