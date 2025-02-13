using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.Cache
{
    public class CustomCache : ICustomCache
    {
        private readonly IMemoryCache _memoryCache;
        public CustomCache(IMemoryCache cache)
        {
            _memoryCache = cache;
        }
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public T Set<T>(string key, T value, TimeSpan expirationTime)
        {
            return _memoryCache.Set<T>(key, value, expirationTime);
        }
    }
}
