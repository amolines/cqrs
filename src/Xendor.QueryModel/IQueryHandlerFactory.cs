using Xendor.QueryModel.Criteria;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public interface IQueryHandlerFactory : ISingletonLifestyle
    {
        IQueryHandler<TIn> CreateQueryHandler<TIn>()
            where TIn : IMetaDataExpression;
    }
}