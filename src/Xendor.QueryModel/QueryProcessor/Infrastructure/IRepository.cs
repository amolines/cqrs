using System.Collections.Generic;

using System.Threading.Tasks;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public interface IRepository<TOut>
        where TOut : IDto
    {
        Task<IEnumerable<TOut>> ExecuteReaderAsync(IQuery query);
        Task<object> ExecuteScalarAsync(IQuery query);
    }
}