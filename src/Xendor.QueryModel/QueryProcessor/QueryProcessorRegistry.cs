using System;
using Microsoft.Extensions.Logging;
using Xendor.QueryModel.Expressions;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel.QueryProcessor
{
    public class QueryProcessorRegistry : IQueryProcessorRegistry
    {
        private readonly IDependencyResolver _serviceProvider;

        public QueryProcessorRegistry(IDependencyResolver serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public IQueryProcessor<TCriteria> FindQueryProcessor<TCriteria>()
            where TCriteria : IMetaDataExpression
        {

            var queryProcessor = _serviceProvider.GetService<IQueryProcessor<TCriteria>>();
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();

            var loggingProcessor = new LoggingQueryProcessor<TCriteria>(queryProcessor, loggerFactory);

            return loggingProcessor;
        }

      
    }
}
