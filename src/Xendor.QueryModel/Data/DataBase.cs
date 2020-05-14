using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.Data
{
    public class DataBase : IDataBase 
    {
        private readonly IConnection _connectionString;
        private readonly DbProviderFactory _dbProviderFactory;
        private DbConnection _dbConnection;
        public DataBase(IConnection connectionString, DbProviderFactory dbProviderFactory)
        {
           
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _dbProviderFactory = dbProviderFactory ?? throw new ArgumentNullException(nameof(dbProviderFactory));
            Init();
        }

        private void Init()
        {
            _dbConnection = _dbProviderFactory.CreateConnection();
            if(_dbConnection != null)
                _dbConnection.ConnectionString = _connectionString.ConnectionString;
        }
        private DbCommand CreateDbCommand(IQuery query)
        {
            var command = _dbConnection.CreateCommand();
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
        #region IConnection
        public void Dispose()
        {
            _dbConnection.Dispose();
        }

        public async Task OpenAsync()
        {
            if(_dbConnection.State != ConnectionState.Open)
                await _dbConnection.OpenAsync();

        }

       
        public void Close()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        #endregion
        #region ICommand
        public async Task<DbDataReader> ExecuteReaderAsync(IQuery query)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                await OpenAsync();
            }
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteReaderAsync();
        }

        public async Task<object> ExecuteScalarAsync(IQuery query)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                await OpenAsync();
            }
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteScalarAsync();
        }
        #endregion
    }
}