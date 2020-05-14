using System.Collections.Generic;

namespace Xendor.QueryModel.QueryProcessor
{
    public class SliceQueryResponse<TOut> : QueryResponse<TOut>
        where TOut : IDto
    {

        public SliceQueryResponse(IEnumerable<TOut> data, SliceHeader header) 
            : base(data,header)
        {

        }

    }
}