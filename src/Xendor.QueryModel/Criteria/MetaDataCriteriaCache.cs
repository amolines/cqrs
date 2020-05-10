using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.Criteria
{
    public sealed class MetaDataCriteriaCache : IMetaDataCriteriaCache
    {
        private readonly IDictionary<Type, IDictionary<string, Type>> _fields;
        private readonly IDictionary<Type, IDictionary<string, Type>> _fullTextSearchFields;
        private readonly IDictionary<Type, IDictionary<string, Type>> _embedFields;
        private static readonly Lazy<MetaDataCriteriaCache>
            Lazy =
                new Lazy<MetaDataCriteriaCache>
                    (() => new MetaDataCriteriaCache());

        private MetaDataCriteriaCache()
        {
            _fields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
            _fullTextSearchFields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
            _embedFields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
        }


        public static MetaDataCriteriaCache Instance => Lazy.Value;

        public IDictionary<string, Type> GetFields<TMetaData>()
            where TMetaData : IMetaDataCriteria
        {
            if (_fields.ContainsKey(typeof(TMetaData))) return _fields[typeof(TMetaData)];
            var fields = FieldAttribute.GetFields<TMetaData>();
            _fields.Add(typeof(TMetaData), fields);
            return fields;

        }

        public IDictionary<string, Type> GetFullTextSearchFields<TMetaData>()
            where TMetaData : IMetaDataCriteria
        {
            if (_fullTextSearchFields.ContainsKey(typeof(TMetaData))) return _fullTextSearchFields[typeof(TMetaData)];
            var fields = FieldAttribute.GetFields<TMetaData>(true);
            _fullTextSearchFields.Add(typeof(TMetaData), fields);
            return fields;
        }

        public IDictionary<string, Type> GetEmbedFields<TMetaData>()
            where TMetaData : IMetaDataCriteria
        {
            if (_embedFields.ContainsKey(typeof(TMetaData))) return _embedFields[typeof(TMetaData)];
            var fields = EmbedFieldAttribute.GetFields<TMetaData>();
            _embedFields.Add(typeof(TMetaData), fields);
            return fields;
        }
    }
}