using System;

namespace Xendor.QueryModel.Exceptions
{
    public class EmbedQueryHandlerNotFoundException : Exception
    {
        public EmbedQueryHandlerNotFoundException(Type type) :
            base($"Embed query handler not found for dto type: {type}")
        {
        }
    }
}