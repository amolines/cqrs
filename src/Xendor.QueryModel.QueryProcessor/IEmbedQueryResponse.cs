using System.Collections.Generic;

namespace Xendor.QueryModel.QueryProcessor
{
    public interface IEmbedQueryResponse<out TEntity> : IQueryResponse
        where TEntity : class
    {
        IEnumerable<TEntity> Data { get; }
    }
}