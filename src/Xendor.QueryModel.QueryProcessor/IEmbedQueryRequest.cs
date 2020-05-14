namespace Xendor.QueryModel.QueryProcessor
{
    public interface IEmbedQueryRequest<TEntity> : IQueryRequest<IEmbedQueryResponse<TEntity>>
        where TEntity : class
    {
        object Id { get; }
    }
}