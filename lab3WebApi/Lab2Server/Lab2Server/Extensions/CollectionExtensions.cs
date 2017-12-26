using System.Linq;
using System.Collections.Generic;

namespace Lab2Server.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                collection.Add(item);
            }
        }

        public static void AddRangeExceptExisting<T>(this ICollection<T> collection, IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            collection.AddRange(items.Except(collection, comparer));
        }
    }
}