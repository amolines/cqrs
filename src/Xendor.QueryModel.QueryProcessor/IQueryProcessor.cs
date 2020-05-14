using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor
{
    public interface IQueryProcessor<in TRequest, TResponse>
        where TRequest : IQueryRequest<TResponse>
        where TResponse : IQueryResponse
    {
        Task<TResponse> ProcessAsync(TRequest request);
    }
}