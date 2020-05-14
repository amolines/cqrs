namespace Xendor.QueryModel.QueryProcessor
{
    public interface IEmbedQueryProcessor<TEntity> : IQueryProcessor<IEmbedQueryRequest<TEntity>, IEmbedQueryResponse<TEntity>>
        where TEntity : class
    {

    }
}