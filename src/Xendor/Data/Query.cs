using System.Collections.Generic;
using Xendor.EventBus;

namespace Xendor.Data
{
    public abstract class Query  : IQuery
    {
        protected Query() { }

        protected Query(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }
        protected Query( Event @event , IDictionary<string, object> parameters = null)
        {
            Parameters = parameters;
            Event = @event;
        }
        public IDictionary<string, object> Parameters { get; }
        public abstract string Sql { get; }
        public Event Event { get; }
    }
}