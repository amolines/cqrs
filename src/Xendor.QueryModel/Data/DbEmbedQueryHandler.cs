using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;


namespace Xendor.QueryModel.Data
{
    public class DbEmbedQueryHandler<TOut, TQuery> : IEmbedQueryHandler<TOut>
        where TOut : IDto
        where TQuery : IEmbedSelectQuery, new()
    {
        private readonly IDataBase _connection;
        private readonly IDataMapper<DbDataReader, IEnumerable<TOut>> _outDataMapper;
        private readonly IFactoryExpression<ISelectQuery> _factoryExpression;

        public DbEmbedQueryHandler(IDataBase connection,
            IDataMapper<DbDataReader, IEnumerable<TOut>> outDataMapper,
            IFactoryExpression<ISelectQuery> factoryExpression)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _outDataMapper = outDataMapper ?? throw new ArgumentNullException(nameof(outDataMapper));
            _factoryExpression = factoryExpression ?? throw new ArgumentNullException(nameof(factoryExpression));
        }
        public async Task<IEnumerable<TOut>> Handle(long id)
        {
         
            var query = new TQuery();
            query.SetId(id);
            var dbDataReader = await _connection.ExecuteReaderAsync(query);
            var data = _outDataMapper.Mapper(dbDataReader);
            return data;
        }
    }
}