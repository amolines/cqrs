using System;
using System.Collections.Generic;

namespace Xendor.Extensions.Collections.Generic
{
    public static class DictionaryExtensions
    {
       
        public static bool TryAddRange<TKey, TValue>(this Dictionary<TKey, TValue> source,Dictionary<TKey, TValue> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var value in collection)
            {
                if (source.ContainsKey(value.Key))
                {
                    return false;
                }
            }


            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
            }
            return true;
        }
    }
}