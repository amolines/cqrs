using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendor.QueryModel.Criteria;

namespace Xendor.QueryModel
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryHandlerFactory _queryHandlerFactory;
        private readonly IEmbedQueryHandlerFactory _embedQueryHandlerFactory;
        public QueryDispatcher(IQueryHandlerFactory queryHandlerFactory, IEmbedQueryHandlerFactory embedQueryHandlerFactory)
        {
            _queryHandlerFactory = queryHandlerFactory ?? throw new ArgumentNullException(nameof(queryHandlerFactory));
            _embedQueryHandlerFactory = embedQueryHandlerFactory ?? throw new ArgumentNullException(nameof(embedQueryHandlerFactory));
        }

        

        public Task<IQueryResult> Submit<TIn>(Criteria<TIn> criteria) 
            where TIn : IMetaDataExpression
        {
            var handler = _queryHandlerFactory.CreateQueryHandler<TIn>();
            var result = handler.Handle(criteria);
            return result;
        }

        public Task<IEnumerable<TOut>> EmbedSubmit<TOut>(long id) 
            where TOut : IDto
        {
            var handler = _embedQueryHandlerFactory.CreateEmbedQueryHandler<TOut>();
            var result = handler.Handle(id);
            return result;
        }
    }
}