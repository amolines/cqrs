using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Xendor.QueryModel.QueryProcessor
{
    public class LoggingQueryProcessor<TRequest, TResponse> : IQueryProcessor<TRequest, TResponse>
        where TRequest : IQueryRequest<TResponse>
        where TResponse : IQueryResponse
    {
        private readonly IQueryProcessor<TRequest, TResponse> _nextLinkInChain;
        private readonly ILogger _logger;

        public LoggingQueryProcessor(IQueryProcessor<TRequest, TResponse> processor, ILoggerFactory loggerFactory)
        {
            _nextLinkInChain = processor ?? throw new ArgumentNullException(nameof(processor));
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger("Application");
        }
        public async Task<TResponse> ProcessAsync(TRequest request)
        {
            TResponse response;
            var requestName = typeof(TRequest);
            var responseName = typeof(TResponse);
            try
            {
                _logger.LogInformation("Begin Query (Request:{requestName}) => Response:{responseName}", requestName, responseName);
                response = await _nextLinkInChain.ProcessAsync(request);
                _logger.LogInformation("End Query (Request:{requestName}) => Response:{responseName}", requestName, responseName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Query (Request:{requestName}) => Response:{responseName}", requestName, responseName);
                throw;
            }
            return response;
        }
    }
}