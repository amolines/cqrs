using System.Collections;

namespace Xendor.QueryModel
{
    public interface IQueryResult
    {
        Header Header { get; }
        IEnumerable Data { get; }
    }
}