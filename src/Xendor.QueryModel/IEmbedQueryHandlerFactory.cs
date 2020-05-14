

namespace Xendor.QueryModel
{
    public interface IEmbedQueryHandlerFactory 
    {
        IEmbedQueryHandler<TOut> CreateEmbedQueryHandler<TOut>()
            where TOut : IDto;


    }
}