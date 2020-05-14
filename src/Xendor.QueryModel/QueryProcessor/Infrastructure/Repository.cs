using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public class Repository<TOut> : IRepository<TOut>
        where TOut : IDto 
    {
        private readonly IDataBase _dataBase;
        private readonly IDataMapper<TOut> _dataMapper;
        public Repository(IDataBase dataBase, IDataMapper<TOut> dataMapper)
        {
            _dataBase = dataBase ?? throw new ArgumentNullException(nameof(dataBase));
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
        }
        private DbCommand CreateDbCommand(IQuery query)
        {
            var command = _dataBase.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query.Sql;
            if (query.Parameters == null) return command;
            foreach (var parameter in query.Parameters)
            {
                var dbParameter = command.CreateParameter();
                dbParameter.ParameterName = parameter.Key;
                dbParameter.Value = parameter.Value;
                command.Parameters.Add(dbParameter);
            }
            return command;
        }

        public async Task<IEnumerable<TOut>> ExecuteReaderAsync(IQuery query)
        {
            await _dataBase.OpenAsync();
            var cmd = CreateDbCommand(query);
            var dataReader = await cmd.ExecuteReaderAsync();
            return _dataMapper.Mapper(dataReader);
        }

        public async Task<object> ExecuteScalarAsync(IQuery query)
        {
            await _dataBase.OpenAsync();
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteScalarAsync();
        }
    }
}