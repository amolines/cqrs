using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria
{
    public interface IMetaDataCriteriaCache
    {
        IDictionary<string, Type> GetFields<TMetaData>()
            where TMetaData : IMetaDataCriteria;

        IDictionary<string, Type> GetFullTextSearchFields<TMetaData>()
            where TMetaData : IMetaDataCriteria;

        IDictionary<string, Type> GetEmbedFields<TMetaData>()
            where TMetaData : IMetaDataCriteria;
    }
}