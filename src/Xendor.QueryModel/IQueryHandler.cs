using System.Threading.Tasks;
using Xendor.QueryModel.Criteria;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{

    public interface IQueryHandler<TIn> : IScopedLifestyle 
        where TIn : IMetaDataExpression
    {
        Task<IQueryResult> Handle(Criteria<TIn> criteria);
    }
}