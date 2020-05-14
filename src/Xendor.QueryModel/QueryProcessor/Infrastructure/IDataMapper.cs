using System.Collections.Generic;
using System.Data.Common;

namespace Xendor.QueryModel.QueryProcessor.Infrastructure
{
    public interface IDataMapper<out TOut>
        where TOut : IDto
    {
        IEnumerable<TOut> Mapper(DbDataReader source);
    }
}