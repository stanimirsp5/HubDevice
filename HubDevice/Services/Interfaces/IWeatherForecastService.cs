namespace HubDevice.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetForecast(string key);
        Task AddForecast(string key, string value);
        Task DeleteForecast(string key);
    }
}
