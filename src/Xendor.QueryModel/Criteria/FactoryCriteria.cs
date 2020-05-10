using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Xendor.QueryModel.Criteria
{
    public abstract class FactoryCriteria<TMetaData, TCriteria, TCriteriaEmpty> : IFactoryCriteria<TMetaData, TCriteria>
        where TMetaData : IMetaDataCriteria
        where TCriteria : ICriteria<TMetaData>
        where TCriteriaEmpty : TCriteria, new()
    {
        public delegate bool TryParseHandler<T>(string value, out T result);
        public delegate T ParseHandler<T>(string value);
        private readonly IQueryCollection _queryCollection;
        private readonly IMetaDataCriteriaCache _metaDataCriteriaCache;
        protected FactoryCriteria(IQueryCollection queryCollection)
        {
            _queryCollection = queryCollection;
            _metaDataCriteriaCache = MetaDataCriteriaCache.Instance;
        }

        protected bool ContainsKey(string key)
        {
            return _queryCollection.ContainsKey(key);
        }
        protected bool TryGetValue(string key, out string[] value)
        {
            if (_queryCollection.TryGetValue(key, out var values))
            {
                value = values.ToArray();
                return true;
            }
            value = new string[] { };
            return false;
        }
        protected string[] GetValue(string key)
        {
            return _queryCollection[key].ToArray();
        }
        protected int Count(string key)
        {
            return ContainsKey(key) ? _queryCollection[key].Count : 0;
        }
        protected bool TryParseValue<T>(string key, TryParseHandler<T> handler, out T result)
            where T : struct
        {
            result = default;
            if (string.IsNullOrEmpty(key)) return false;
            if (!TryGetValue(key, out var values)) return false;
            return values.Length.Equals(1) && handler(values[0], out result);
        }
        protected T ParseValue<T>(string key, ParseHandler<T> handler)
            where T : struct
        {
            var values = GetValue(key);
            if (values.Length.Equals(1))
            {
                return handler(values[0]);
            }
            throw new InvalidCastException();
        }
        protected bool TryParseValues<T>(string key, TryParseHandler<T> handler, out T[] result)
            where T : struct
        {

            result = null;
            if (string.IsNullOrEmpty(key)) return false;
            if (!TryGetValue(key, out var values)) return false;

            var results = new List<T>();
            foreach (var v in values)
            {
                if (handler(v, out var value))
                    results.Add(value);
            }
            if (!values.Length.Equals(results.Count)) return false;

            result = results.ToArray();
            return true;

        }
        protected T[] ParseValues<T>(string key, ParseHandler<T> handler)
            where T : struct
        {
            var values = GetValue(key);

            return values.Select(v => handler(v)).ToArray();
        }
        protected IMetaDataCriteriaCache Cache => _metaDataCriteriaCache;
        public TCriteria Create(IQueryCollection queryCollection)
        {
            if (!Contains() || !Validate()) return new TCriteriaEmpty();
            return Extract();
        }
        protected abstract bool Contains();
        protected abstract bool Validate();
        protected abstract TCriteria Extract();
    }
}