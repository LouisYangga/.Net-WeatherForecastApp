using WeatherForecastApp.OpenWeatherMap_Model;

namespace WeatherForecastApp.Repositories
{
    public interface IWForecastRepository
    {
        WeatherResponse GetForecast(string city);
        Task<List<string>> GetCities(string country);
    }
}