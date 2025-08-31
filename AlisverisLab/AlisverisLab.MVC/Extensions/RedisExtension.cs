using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AlisverisLab.MVC.Extensions
{
    public static class RedisExtension
    {
        static readonly ConnectionMultiplexer _redisConnection;
        static readonly IDatabase _database;

        static RedisExtension()
        {
            _redisConnection = ConnectionMultiplexer.Connect("localhost");
            _database = _redisConnection.GetDatabase();
        }

        public static void Set<T>(this IDatabase redisDB, string key, T value, TimeSpan? expiry)
        {
            string data = JsonConvert.SerializeObject(value);
            redisDB.StringSet(key, data, expiry);
        }

        public static T Get<T>(this IDatabase redisDB, string key)
        {
            string data = redisDB.StringGet(key);

            if (string.IsNullOrEmpty(data))
                return default(T);
            
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void Remove(this IDatabase redisDB, string key)
        {
            redisDB.KeyDelete(key);
        }
    }
}
