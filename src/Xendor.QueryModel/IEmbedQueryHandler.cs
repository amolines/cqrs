using System.Collections.Generic;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public interface IEmbedQueryHandler<TOut> : IScopedLifestyle
        where TOut : IDto
    {
        Task<IEnumerable<TOut>> Handle(long id);

    }



}