using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;
using HubDevice.Services.Interfaces;

namespace HubDevice.Repository
{

    // Redis Documentation https://www.w3resource.com/redis/redis-set-key-value.php
    // .net stackexchange redis documentation https://stackexchange.github.io/StackExchange.Redis/
    // .net stackexchange redis Basis Documentation https://stackexchange.github.io/StackExchange.Redis/Basics
    // return types in redis https://stackoverflow.com/questions/37953019/wrongtype-operation-against-a-key-holding-the-wrong-kind-of-value-php 

    public class CacheRepository : ICacheRepository
    {
        private readonly IDatabase _cache;
        public CacheRepository()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            _cache = db;
        }

        public async Task<string> GetFromCache<T>(string key) where T : class
        {
            string res = await _cache.StringGetAsync(key);

            return res;
        }

        public async Task SetCache<T>(string key, T value) where T : class
        {
            var response = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, response);
        }

        public async Task Delete(string key)
        {

            await _cache.KeyDeleteAsync(key);
        }
    }
}

