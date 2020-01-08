//@BaseCode
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonBase.Extensions
{
    public static partial class StringExtensions
    {
        public static bool HasContent(this string source)
        {
            return string.IsNullOrEmpty(source) == false;
        }

        public static bool NotEquals(this string source, string other)
        {
            return source.Equals(other) == false;
        }

        public static IEnumerable<string[]> Split(this IEnumerable<string> source, string separator)
        {
            source.CheckArgument(nameof(source));

            return source.Select(l => string.IsNullOrEmpty(l) ? new string[0] : l.Split(separator));
        }
        public static IEnumerable<T> SplitAndMap<T>(this IEnumerable<string> source, string separator, Func<string[], T> mapper)
        {
            source.CheckArgument(nameof(source));
            mapper.CheckArgument(nameof(mapper));

            return source.Split(separator).Select(d => mapper(d));
        }
        public static IEnumerable<T> SplitAndMap<T>(this IEnumerable<string> source, string separator, Func<string[], string[], T> mapper)
        {
            source.CheckArgument(nameof(source));
            mapper.CheckArgument(nameof(mapper));

            var splitSource = source.Split(separator);
            var header = splitSource.FirstOrDefault();

            return splitSource.Skip(1).Select(d => mapper(d, header));
        }
    }
}
