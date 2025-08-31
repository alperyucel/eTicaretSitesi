using Microsoft.Extensions.Caching.Memory;

namespace AlisverisLab.MVC.Extensions
{
    public static class MemoryCacheExtension
    {
        //static readonly MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
        public static void SetCache<T>(this IMemoryCache cache, string key, T value, TimeSpan? expireTime)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expireTime ?? TimeSpan.FromMinutes(10)
            };
            cache.Set(key, value, options);
        }

        public static T GetCache<T>(this IMemoryCache cache, string key)
        {
            if (cache.TryGetValue(key, out T value))
                return value;

            return default(T);
        }

        public static void RemoveCache(this IMemoryCache cache, string key)
        {
            cache.Remove(key);
        }
    }
}
