using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public interface IRepository
    {
        Task<DbDataReader> ExecuteReaderAsync(IQuery query);
        Task<object> ExecuteScalarAsync(IQuery query);
    }
}