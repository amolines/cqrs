using System.Collections.Generic;
using System.Threading.Tasks;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel
{
    public interface IQueryDispatcher 
    {
        Task<IQueryResult> Submit<TIn>(Criteria<TIn> criteria)
            where TIn : IMetaDataExpression;

        Task<IEnumerable<TOut>> EmbedSubmit<TOut>(long id)
            where TOut : IDto;



    }
}