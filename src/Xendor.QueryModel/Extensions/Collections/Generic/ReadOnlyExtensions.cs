using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xendor.QueryModel.Extensions.Collections.Generic
{
    public static class ReadOnlyExtensions
    {
        public static IEnumerable<T> ToReadOnly<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));


            return collection is ReadOnlyCollection<T> ? collection : new List<T>(collection).AsReadOnly();
        }

    }
}