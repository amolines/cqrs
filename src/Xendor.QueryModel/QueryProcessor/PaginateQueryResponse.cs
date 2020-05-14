using System.Collections.Generic;

namespace Xendor.QueryModel.QueryProcessor
{
    public class PaginateQueryResponse<TOut> : QueryResponse<TOut>
        where TOut : IDto
    {
        public PaginateQueryResponse(IEnumerable<TOut> data , PaginateHeader header)
            : base(data,header)
        {

        }

    }
}