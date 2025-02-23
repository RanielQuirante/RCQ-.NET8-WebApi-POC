using Microsoft.Extensions.Caching.Memory;
using StradaTechnicalInterview.Services.Interfaces;

namespace StradaTechnicalInterview.Services.Implementations
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetCacheOneDay<T>(string key, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            };

            _memoryCache.Set(key, value, cacheEntryOptions);
        }

        public void SetCacheOneHour<T>(string key, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            };

            _memoryCache.Set(key, value, cacheEntryOptions);
        }

        public T GetCache<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T value);
            return value;
        }

        public void RemoveKey(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}