using System.Threading.Tasks;
using Xendor.ServiceLocator;

namespace Xendor.QueryModel
{

    public interface IQueryHandler<TIn> : IScopedLifestyle 
        where TIn : class
    {
        Task<IQueryResult> Handle(Criteria<TIn> criteria);
    }
}