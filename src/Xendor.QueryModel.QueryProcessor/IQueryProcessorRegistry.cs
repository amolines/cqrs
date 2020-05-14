namespace Xendor.QueryModel.QueryProcessor
{
    public interface IQueryProcessorRegistry
    {
        IQueryProcessor<TRequest, TResponse> FindQueryProcessor<TRequest, TResponse>()
            where TRequest : IQueryRequest<TResponse>
            where TResponse : IQueryResponse;
    }
}