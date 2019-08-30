using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public interface IEmbedQueryHandlerFactory : ISingletonLifestyle
    {
        IEmbedQueryHandler<TOut> CreateEmbedQueryHandler<TOut>()
            where TOut : IDto;


    }
}