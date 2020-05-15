using System;
using System.Collections;
using System.Threading.Tasks;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.EmbedCollection;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{

    public class DbQueryProcessor<TCriteria, TQuery, TOut> : IQueryProcessor<TCriteria>
        where TCriteria : IMetaDataExpression
        where TQuery : Query, new()
        where TOut : IDto
    {
        protected readonly IRepository<TOut> _repository;
        protected readonly IQueryProcessorRegistry _queryProcessorRegistry;

        public DbQueryProcessor(IRepository<TOut> repository, IQueryProcessorRegistry queryProcessorRegistry)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _queryProcessorRegistry = queryProcessorRegistry ?? throw new ArgumentNullException(nameof(queryProcessorRegistry));
        }
        protected async Task<ICollection> ProcessAsync<T>(Criteria<T> criteria)
            where T : IMetaDataExpression
        {
            var query = _queryProcessorRegistry.FindQueryProcessor<T>();
            var response = await query.ProcessAsync(new QueryRequest<T>(criteria));
            return response.Data; 
        }
        protected virtual void SetEmbeds(IEmbedCollectionExpression embeds, TOut root)
        {
            
        }
        public async Task<IQueryResponse> ProcessAsync(QueryRequest<TCriteria> request)
        {
            var query = CreateQuery(request.Criteria);
            try
            {
                var data = await _repository.ExecuteReaderAsync(query);
                foreach (var root in data)
                {
                    if (request.Criteria.Embeds != null && request.Criteria.Embeds.Any())
                        SetEmbeds(request.Criteria.Embeds, root);
                }
                QueryResponse<TOut> result = null;
                if (!request.Criteria.IsSlice && !request.Criteria.IsPaginate)
                {
                    result = new QueryResponse<TOut>(data);
                }
                else
                {
                    var total = await _repository.ExecuteScalarAsync(query.SqlCount);
                    var value = (long)Convert.ChangeType(total, typeof(long));
                    if (request.Criteria.Paginate != null)
                    {
                        result = new PaginateQueryResponse<TOut>(data, new PaginateHeader(request.Criteria, value));
                    }
                    else
                    {
                        result = new SliceQueryResponse<TOut>(data, new SliceHeader(value));
                    }
                }
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected IQuery CreateQuery(ICriteria criteria)
        {
            var select = new TQuery();
            select.SetCriteria(criteria);
            return select;
        }


    }
}