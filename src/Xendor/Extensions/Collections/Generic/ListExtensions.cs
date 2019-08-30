using System.Collections.Generic;

namespace Xendor.Extensions.Collections.Generic
{
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count.Equals(0);
        }
    }
}