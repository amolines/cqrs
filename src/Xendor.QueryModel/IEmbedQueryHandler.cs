using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendor.QueryModel
{
    public interface IEmbedQueryHandler<TOut> 
        where TOut : IDto
    {
        Task<IEnumerable<TOut>> Handle(long id);

    }



}