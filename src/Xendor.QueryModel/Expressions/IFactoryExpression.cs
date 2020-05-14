using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Expressions
{
    public interface IFactoryExpression<TMetaData, out TCriteria>
        where TMetaData : IMetaDataExpression
        where TCriteria : IExpression
    {
        TCriteria Create(IQueryCollection queryCollection);
    }
}