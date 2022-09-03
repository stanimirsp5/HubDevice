using System;
namespace HubDevice.Repository
{
    public interface ICacheRepository
    {
        Task<string> GetFromCache<T>(string key) where T : class;
        Task SetCache<T>(string key, T value) where T : class;
        Task Delete(string key);
    }
}

