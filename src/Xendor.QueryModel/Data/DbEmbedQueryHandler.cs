using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Xendor.Data;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.Data
{
    public class DbEmbedQueryHandler<TOut , TQuery> : IEmbedQueryHandler<TOut>
        where TOut : IDto
        where TQuery : IEmbedSelectQuery, new()
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDataMapper<DbDataReader, IEnumerable<TOut>> _outDataMapper;
        private readonly IFactoryExpression<ISelectQuery> _factoryExpression;

        public DbEmbedQueryHandler(IUnitOfWorkManager unitOfWorkManager,
            IDataMapper<DbDataReader, IEnumerable<TOut>> outDataMapper,
            IFactoryExpression<ISelectQuery> factoryExpression)
        {
            _unitOfWorkManager = unitOfWorkManager ?? throw new ArgumentNullException(nameof(unitOfWorkManager));
            _outDataMapper = outDataMapper ?? throw new ArgumentNullException(nameof(outDataMapper));
            _factoryExpression = factoryExpression ?? throw new ArgumentNullException(nameof(factoryExpression));
        }
        public async Task<IEnumerable<TOut>> Handle(long id)
        {
            var unitofWork = _unitOfWorkManager.New();
            var query = new TQuery();
            query.SetId(id);
            var dbDataReader = await unitofWork.ExecuteReaderAsync(query);
            var data = _outDataMapper.Mapper(dbDataReader);


            return data;
        }
    }
}