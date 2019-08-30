using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.Data
{
    /// <summary>
    /// A Unit of Work keeps track of everything you do during a business transaction that can affect the database.
    /// When you're done, it figures out everything that needs to be done to alter the database as a result of your work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<DbDataReader> ExecuteReaderAsync(IQuery query);
        Task<int> ExecuteNonQueryAsync(IQuery query);
        Task<object> ExecuteScalarAsync(IQuery query);
        void Commit();
        void RollBack();
        UnitOfWorkState State { get; }
        IUnitOfWorkConnection Connection { get; }
        bool Available { get; }
    }
}