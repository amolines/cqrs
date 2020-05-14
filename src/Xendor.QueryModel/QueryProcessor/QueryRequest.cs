using System;
using Xendor.QueryModel.Expressions;

namespace Xendor.QueryModel.QueryProcessor
{
    public class QueryRequest<TMetaData> : IQueryRequest
        where TMetaData : IMetaDataExpression
    {
        private readonly ICriteria _criteria;

        public QueryRequest(Criteria<TMetaData> criteria)
        {
            _criteria = criteria ?? throw new ArgumentException(nameof(criteria));
        }

        public ICriteria Criteria => _criteria;
    }
}