using System;
using System.Collections.Generic;

namespace Xendor.QueryModel.Criteria.FilterCollection
{
    public class FilterCollectionEmptyExpression<TMetaData> : IFilterCollectionExpression
        where TMetaData : IMetaDataExpression
    {


        public IEnumerable<Filter> Filters => new List<Filter>().AsReadOnly();
        public void Add(string name, string value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}