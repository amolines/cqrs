using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Expressions
{
    public interface IMetaDataExpressionCache
    {
        IDictionary<string, Type> GetFields<TMetaData>()
            where TMetaData : IMetaDataExpression;

        IDictionary<string, Type> GetFullTextSearchFields<TMetaData>()
            where TMetaData : IMetaDataExpression;

        IDictionary<string, Type> GetEmbedFields<TMetaData>()
            where TMetaData : IMetaDataExpression;
    }
}