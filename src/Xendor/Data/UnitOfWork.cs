using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using Xendor.Data.Exceptions;
using Xendor.EventBus;
using Xendor.ServiceLocator;

namespace Xendor.Data
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private DbConnection _dbconnection;
        private DbTransaction _dbTransaction;
        private readonly Queue<Event> _events;
        protected UnitOfWork(IUnitOfWorkConnection unitOfWorkConnection)
        {
            Connection = unitOfWorkConnection ?? throw new ArgumentNullException(nameof(unitOfWorkConnection));
            _events = new Queue<Event>();
            Init();
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        protected abstract DbProviderFactory Provider { get; }
        #region Private Methods
        private DbCommand CreateDbCommand(IQuery query)
        {
            var command = _dbconnection.CreateCommand();
            command.Transaction = _dbTransaction;
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
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbconnection.State == ConnectionState.Open)
            {
                _dbconnection.Close();
            }
            _dbTransaction?.Dispose();
            _dbconnection.Dispose();
            State = UnitOfWorkState.Disposed;
            _disposed = true;
        }
        private void BeginTransaction()
        {
            _dbTransaction = _dbconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            State = UnitOfWorkState.InAction;
        }
        private void Init()
        {
            var policy = Policy.Handle<DbException>()
                .WaitAndRetry(Connection.RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        //var logger = ServiceLocatorFactory.Instance().GetService<ILogger<UnitOfWork>>();
                        //logger.LogWarning(ex, "MySql Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                    }
                );
            policy.Execute(() =>
            {
                _dbconnection = Provider.CreateConnection();
                if (_dbconnection == null) return;
                _dbconnection.ConnectionString = Connection.ConnectionString;
                _dbconnection.Open();
                BeginTransaction();
            });
        }
        #endregion

        #region IUnitOfWork
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public async Task<object> ExecuteScalarAsync(IQuery query)
        {
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteScalarAsync();
        }

        public void Commit()
        {
            if (State != UnitOfWorkState.InAction)
                throw new InvalidStateForActionException(State, "Commit");
            _dbTransaction.Commit();
            _dbTransaction.Dispose();

            if (_events.Any())
            {
                var serviceLocator =   ServiceLocatorFactory.Instance();
                var eventBus = serviceLocator.GetService<IEventBus>();
                while (_events.Count > 0)
                {
                    var @event = _events.Dequeue();
                    eventBus.Publish(@event);
                }
            }


            
            State = UnitOfWorkState.Commit;

        }
        public void RollBack()
        {
            if (State != UnitOfWorkState.InAction)
                throw new InvalidStateForActionException(State, "RollBack");
            _dbTransaction?.Rollback();
            _events.Clear();
            State = UnitOfWorkState.RollBack;

        }
        public async Task<DbDataReader> ExecuteReaderAsync(IQuery query)
        {
            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteReaderAsync();
        }
        public async Task<int> ExecuteNonQueryAsync(IQuery query)
        {
            if (query.Event != null)
            {
                _events.Enqueue(query.Event);
            }


            var cmd = CreateDbCommand(query);
            return await cmd.ExecuteNonQueryAsync();
        }
        public UnitOfWorkState State
        {
            get;
            private set ;
        }
        public IUnitOfWorkConnection Connection { get; }
        public bool Available
        {
            get
            {
                switch (State)
                {
                    case UnitOfWorkState.Commit:
                    case UnitOfWorkState.RollBack:
                    case UnitOfWorkState.Disposed:
                        return false;
                    case UnitOfWorkState.InAction:
                        return true;
                    default:
                        return true;
                }
            }
        }

   
        #endregion
    }
}