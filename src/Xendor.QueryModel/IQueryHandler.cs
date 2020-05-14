using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xendor.QueryModel.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace Xendor.QueryModel
{

    public interface IQueryHandler<TIn>  
        where TIn : IMetaDataExpression
    {
        Task<IQueryResult> Handle(Criteria<TIn> criteria);
    }


   
}