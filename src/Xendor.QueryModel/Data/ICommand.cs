using System.Data.Common;
using System.Threading.Tasks;

namespace Xendor.QueryModel.Data
{
    public interface ICommand
    {
        Task<DbDataReader> ExecuteReaderAsync(IQuery query);
        Task<object> ExecuteScalarAsync(IQuery query);
    }

   
}