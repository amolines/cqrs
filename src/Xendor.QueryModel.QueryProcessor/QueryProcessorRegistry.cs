using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace Xendor.QueryModel.QueryProcessor
{
    public class QueryProcessorRegistry : IQueryProcessorRegistry
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryProcessorRegistry(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public IQueryProcessor<TRequest, TResponse> FindQueryProcessor<TRequest, TResponse>()
            where TRequest : IQueryRequest<TResponse>
            where TResponse : IQueryResponse
        {

            var queryProcessor = _serviceProvider.GetService<IQueryProcessor<TRequest, TResponse>>();
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();

            var loggingProcessor = new LoggingQueryProcessor<TRequest, TResponse>(queryProcessor, loggerFactory);

            return loggingProcessor;
        }
    }
}
