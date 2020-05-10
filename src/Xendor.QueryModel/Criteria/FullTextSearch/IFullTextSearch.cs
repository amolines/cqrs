using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public interface IFullTextSearch<TMetaData> : ICriteria<TMetaData>
        where TMetaData : IMetaDataCriteria
    {
        IEnumerable<string> Name {get; }
        string Value { get; }
    }
}