using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Application.Extensions
{
    public static class IAsyncEnumerableExtensions
    {
        public static IEnumerable<T> CollectAsync(this IAsyncEnumerable<T> that) where T : class
        {
            var enumerable = new List<T>();

            await foreach (var item in that)
            {
                func.Invoke(item);
                enumerable.Add(item);
            }

            return enumerable;
		}
    }
}
