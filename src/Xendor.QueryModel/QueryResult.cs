using System.Collections;
using System.Collections.Generic;
using Xendor.QueryModel.Extensions.Collections.Generic;

namespace Xendor.QueryModel
{
    public class QueryResult<TOut> : IQueryResult
        where TOut : IDto
    {
        private readonly IEnumerable<TOut> _data;
        public QueryResult(IEnumerable<TOut> data, Header header = null)
        {
            Header = header;
            _data = data;
        }
        public Header Header { get; }
        public IEnumerable Data => _data.ToReadOnly<TOut>();
    }
}