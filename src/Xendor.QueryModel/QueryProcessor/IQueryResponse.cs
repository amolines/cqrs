using System.Collections;

namespace Xendor.QueryModel.QueryProcessor
{
    public interface IQueryResponse
    {
        Header Header { get; }
        ICollection Data { get; }
    }
}