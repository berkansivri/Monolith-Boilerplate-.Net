using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PRS.Core.Caching
{
    public static class InMemoryCache
    {
        public static T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int expiration = 30) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(expiration));
            }
            return item;
        }
        public static void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }
    }
}
