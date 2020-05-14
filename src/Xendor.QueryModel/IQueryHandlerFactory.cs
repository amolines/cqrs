using Xendor.QueryModel.Expressions;


namespace Xendor.QueryModel
{
    public interface IQueryHandlerFactory 
    {
        IQueryHandler<TIn> CreateQueryHandler<TIn>()
            where TIn : IMetaDataExpression;
    }
}