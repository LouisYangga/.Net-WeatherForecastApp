namespace WeatherForecastApp.Services
{
    public interface IWForecastService
    {
        float CelsiusToFahrenheit(float celsius);
        string ConvertToLocalTime(DateTime utcTime, int timeZoneOffsetSeconds);
    }

}