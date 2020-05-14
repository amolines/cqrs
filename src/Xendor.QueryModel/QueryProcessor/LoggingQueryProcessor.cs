using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.QueryProcessor
{
    public class LoggingQueryProcessor<TCriteria> : IQueryProcessor<TCriteria>
        where TCriteria : IMetaDataExpression
    {
        private readonly IQueryProcessor<TCriteria> _nextLinkInChain;
        private readonly ILogger _logger;

        public LoggingQueryProcessor(IQueryProcessor<TCriteria> processor, ILoggerFactory loggerFactory)
        {
            _nextLinkInChain = processor ?? throw new ArgumentNullException(nameof(processor));
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger("Application");
        }
        public async Task<IQueryResponse> ProcessAsync(QueryRequest<TCriteria> request)
        {
            IQueryResponse response;
            var requestName = typeof(TCriteria);
            try
            {
                _logger.LogInformation("Begin Query => Request:{requestName}", requestName);
                response = await _nextLinkInChain.ProcessAsync(request);
                _logger.LogInformation("End Query => Request:{requestName} ", requestName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Query => Request:{requestName} ", requestName);
                throw;
            }
            return response;
        }
    }
}