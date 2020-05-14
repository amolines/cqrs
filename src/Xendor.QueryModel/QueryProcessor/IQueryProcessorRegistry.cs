using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.QueryProcessor
{
    public interface IQueryProcessorRegistry
    {
        IQueryProcessor<TCriteria> FindQueryProcessor<TCriteria>()
            where TCriteria : IMetaDataExpression;
    }
}