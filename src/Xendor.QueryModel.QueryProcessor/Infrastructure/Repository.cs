using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IDataBase _dataBase;
        public Repository(IDataBase dataBase)
        {
            _dataBase = dataBase ?? throw new ArgumentNullException(nameof(dataBase));
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

        public async Task<DbDataReader> ExecuteReaderAsync(IQuery query)
        {
            await _dataBase.OpenAsync();
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteReaderAsync();
        }

        public async Task<object> ExecuteScalarAsync(IQuery query)
        {
            await _dataBase.OpenAsync();
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteScalarAsync();
        }
    }
}