using System;

namespace Xendor.QueryModel.Exceptions
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type type) : 
            base($"Query handler not found for criteria type: {type}")
        {
        }
    }
}