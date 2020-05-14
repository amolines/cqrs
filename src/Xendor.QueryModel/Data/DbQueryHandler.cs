using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Xendor.QueryModel.Expressions;
using Xendor.QueryModel.Expressions.EmbedCollection;

namespace Xendor.QueryModel.Data
{
    public class DbQueryHandler<TIn, TOut, TQuery> : IQueryHandler<TIn>
        where TOut : IRootDto
        where TIn : IMetaDataExpression
        where TQuery :  ISelectQuery, new()
    {
        private readonly IDataBase _connection;
        private readonly IDataMapper<DbDataReader, IEnumerable<TOut>> _outDataMapper;
        private readonly IFactoryExpression<ISelectQuery> _factoryExpression;
        protected readonly IQueryDispatcher QueryDispatcher;

        public DbQueryHandler(IDataBase connection,
            IDataMapper<DbDataReader, IEnumerable<TOut>> outDataMapper,
            IFactoryExpression<ISelectQuery> factoryExpression,
            IQueryDispatcher queryDispatcher)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _outDataMapper = outDataMapper ?? throw new ArgumentNullException(nameof(outDataMapper));
            _factoryExpression = factoryExpression ?? throw new ArgumentNullException(nameof(factoryExpression));
            QueryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        protected virtual void SetEmbeds(IEmbedCollectionExpression embeds, IRootDto root)
        {
            foreach (var embed in embeds.Embeds)
            {
                var method = QueryDispatcher.GetType().GetMethod("EmbedSubmit");
                if (method == null) continue;
                var dtoType = method.MakeGenericMethod(embed.Type);
                var task = dtoType.Invoke(QueryDispatcher, new object[] { root.Key });
                var result = task.GetType().GetProperty("Result")?.GetValue(task);
                var property = embed.Name.First().ToString().ToUpper() + embed.Name.Substring(1);
                root.GetType().GetProperty(property)?.SetValue(root, result);
            }
        }
        private async Task<IQueryResult> Execute(ICriteria criteria)
        {
            var query = _factoryExpression.Create<TQuery>(criteria);
            try
            {
                var dbDataReader = await _connection.ExecuteReaderAsync(query);
                var data = _outDataMapper.Mapper(dbDataReader);
                foreach (var root in data)
                {
                    if(criteria.Embeds != null && criteria.Embeds.Any())
                        SetEmbeds(criteria.Embeds, root);
                }

                IQueryResult result;
                if (!criteria.IsSlice && !criteria.IsPaginate)
                {
                    result = new QueryResult<TOut>(data);
                }
                else
                {
                    var total = await _connection.ExecuteScalarAsync(query.SqlCount);
                    var value = (long) Convert.ChangeType(total, typeof(long));
                    if (criteria.Paginate != null)
                    {
                        result = new PaginateQueryResult<TOut>(data, new PaginateQueryHeader(criteria, value));
                    }
                    else
                    {
                        result = new SliceQueryResult<TOut>(data, new SliceQueryHeader(value));
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
        public async Task<IQueryResult> Handle(Criteria<TIn> criteria)
        {
            return await Execute(criteria);
        }
    }
}