using System;
using Xendor.QueryModel.Exceptions;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IDependencyResolver _serviceProvider;

        public QueryHandlerFactory(IDependencyResolver serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IQueryHandler<TIn> CreateQueryHandler<TIn>() 
            where TIn : class
        {
            var handler = _serviceProvider.GetService<IQueryHandler<TIn>>();
            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TIn));
            }
            return handler;
        }
    }
}