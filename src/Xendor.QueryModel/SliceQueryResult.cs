using System.Collections.Generic;

namespace Xendor.QueryModel
{
    public class SliceQueryResult<TOut> : QueryResult<TOut>
        where TOut : IDto
    {

        public SliceQueryResult(IEnumerable<TOut> data, SliceQueryHeader header) 
            : base(data,header)
        {

        }

    }
}