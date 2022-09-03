using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using HubDevice.Services.Interfaces;
using HubDevice.Repository;

namespace HubDevice.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ICacheRepository _cacheRepository;

        public WeatherForecastService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;

        }
        public async Task<WeatherForecast> GetForecast(string key)
        {
           var res = await _cacheRepository.GetFromCache<string>(key);
            return new WeatherForecast() { Summary = res};
        }

        public async Task AddForecast(string key, string value)
        {
            await _cacheRepository.SetCache(key, value);
        }
        public async Task DeleteForecast(string key)
        {
            await _cacheRepository.Delete(key);
        }
    }
}
