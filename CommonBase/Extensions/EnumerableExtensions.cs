//@BaseCode
using System;
using System.Collections.Generic;

namespace CommonBase.Extensions
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<ST> ToEnumerable<T, ST>(this IEnumerable<T> source, Func<T, ST> expandSelector)
        {
            List<ST> expandResult = new List<ST>();

            if (source != null && expandSelector != null)
            {
                foreach (var item in source)
                {
                    var subItem = expandSelector(item);

                    if (subItem != null)
                    {
                        expandResult.Add(subItem);
                    }
                }
            }
            return expandResult;
        }
        public static IEnumerable<ST> FlattenEnumerable<T, ST>(this IEnumerable<T> source, Func<T, IEnumerable<ST>> expandSelector)
        {
            List<ST> expandResult = new List<ST>();

            if (source != null && expandSelector != null)
            {
                foreach (var item in source)
                {
                    var subItems = expandSelector(item);

                    if (subItems != null)
                    {
                        expandResult.AddRange(subItems);
                    }
                }
            }
            return expandResult;
        }

        public static IEnumerable<T> ForeachAction<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source != null && action != null)
            {
                foreach (var item in source)
                {
                    action(item);
                }
            }
            return source;
        }
        public static int NextValue<T>(this IEnumerable<T> source, Func<T, int> getValue)
        {
            int result = 0;

            if (source != null && getValue != null)
            {
                source.ForeachAction(i =>
                {
                    int value = getValue(i);

                    if (value > result)
                    {
                        result = value;
                    }
                });
            }
            return result + 1;
        }
    }
}
