using System.Threading.Tasks;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.QueryProcessor
{

    public interface IQueryProcessor<TCriteria> 
        where TCriteria : IMetaDataExpression
    {
        Task<IQueryResponse> ProcessAsync(QueryRequest<TCriteria> request);
    }


   
}