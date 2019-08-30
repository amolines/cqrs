using System.Collections.Generic;

namespace Xendor.QueryModel
{
    public class PaginateQueryResult<TOut> : QueryResult<TOut>
        where TOut : IDto
    {
        public PaginateQueryResult(IEnumerable<TOut> data , PaginateQueryHeader header)
            : base(data,header)
        {

        }

    }
}