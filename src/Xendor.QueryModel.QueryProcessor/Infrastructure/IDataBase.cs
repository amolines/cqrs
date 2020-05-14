using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public interface IDataBase : IDisposable

    {
        Task OpenAsync();
        DbCommand CreateCommand();
        void Close();
    }
}