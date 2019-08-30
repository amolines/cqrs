using System.Collections.Generic;
using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{
    public interface IQueryDispatcher : ISingletonLifestyle
    {
        Task<IQueryResult> Submit<TIn>(Criteria<TIn> criteria)
            where TIn : class;

        Task<IEnumerable<TOut>> EmbedSubmit<TOut>(long id)
            where TOut : IDto;



    }
}