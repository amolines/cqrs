using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FullTextSearch
{
    public class FullTextSearchEmptyExpression<TMetaData> : IFullTextSearchExpression
        where TMetaData : IMetaDataExpression
    {
        public IEnumerable<string> Name =>new List<string>().AsReadOnly();
        public string Value => string.Empty;
    }
}