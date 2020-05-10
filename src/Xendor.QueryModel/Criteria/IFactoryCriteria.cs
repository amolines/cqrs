using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria
{
    public interface IFactoryCriteria<TMetaData, out TCriteria>
        where TMetaData : IMetaDataCriteria
        where TCriteria : ICriteria<TMetaData>
    {
        TCriteria Create(IQueryCollection queryCollection);
    }
}