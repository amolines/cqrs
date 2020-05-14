using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Xendor.QueryModel.Attributes;

namespace Xendor.QueryModel.Expressions
{
    public sealed class MetaDataExpressionCache : IMetaDataExpressionCache
    {
        private readonly ConcurrentDictionary<Type, IDictionary<string, Type>> _fields;
        private readonly ConcurrentDictionary<Type, IDictionary<string, Type>> _fullTextSearchFields;
        private readonly ConcurrentDictionary<Type, IDictionary<string, Type>> _embedFields;
        private static readonly Lazy<MetaDataExpressionCache>
            Lazy =
                new Lazy<MetaDataExpressionCache>
                    (() => new MetaDataExpressionCache());

        private MetaDataExpressionCache()
        {
            _fields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
            _fullTextSearchFields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
            _embedFields = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
        }


        public static MetaDataExpressionCache Instance => Lazy.Value;

        public IDictionary<string, Type> GetFields<TMetaData>()
            where TMetaData : IMetaDataExpression
        {
            if (_fields.ContainsKey(typeof(TMetaData))) return _fields[typeof(TMetaData)];
            var fields = FieldAttribute.GetFields<TMetaData>();
            _fields.AddOrUpdate(typeof(TMetaData), fields, (type, types) => types);
            return fields;

        }

        public IDictionary<string, Type> GetFullTextSearchFields<TMetaData>()
            where TMetaData : IMetaDataExpression
        {
            if (_fullTextSearchFields.ContainsKey(typeof(TMetaData))) return _fullTextSearchFields[typeof(TMetaData)];
            var fields = FieldAttribute.GetFields<TMetaData>(true);
            _fullTextSearchFields.AddOrUpdate(typeof(TMetaData), fields, (type, types) => types);
            return fields;
        }

        public IDictionary<string, Type> GetEmbedFields<TMetaData>()
            where TMetaData : IMetaDataExpression
        {
            if (_embedFields.ContainsKey(typeof(TMetaData))) return _embedFields[typeof(TMetaData)];
            var fields = EmbedFieldAttribute.GetFields<TMetaData>();
            _embedFields.AddOrUpdate(typeof(TMetaData), fields, (type, types) => types);
            return fields;
        }
    }
}