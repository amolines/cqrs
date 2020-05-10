using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public class FullTextSearchEmpty<TMetaData> : IFullTextSearch<TMetaData>
        where TMetaData : IMetaDataCriteria
    {
        public IEnumerable<string> Name =>new List<string>().AsReadOnly();
        public string Value => string.Empty;
    }
}