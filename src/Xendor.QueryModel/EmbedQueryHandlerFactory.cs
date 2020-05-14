using System;
using Xendor.QueryModel.Exceptions;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public class EmbedQueryHandlerFactory : IEmbedQueryHandlerFactory
    {
        private readonly IDependencyResolver _serviceProvider;

        public EmbedQueryHandlerFactory(IDependencyResolver serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IEmbedQueryHandler<TOut> CreateEmbedQueryHandler<TOut>()
            where TOut : IDto
        {
            var handler = _serviceProvider.GetService<IEmbedQueryHandler<TOut>>();
            if (handler == null)
            {
                throw new EmbedQueryHandlerNotFoundException(typeof(TOut));
            }
            return handler;
        }
    }
}