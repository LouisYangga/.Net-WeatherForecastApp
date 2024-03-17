namespace WeatherForecastApp.Services
{
    public class WForecastService : IWForecastService
    {
        public float CelsiusToFahrenheit(float celsius)
        {
            return (float)Math.Round((celsius * 9 / 5) + 32, 1);
        }

        public string ConvertToLocalTime(DateTime utcTime, int timeZoneOffsetSeconds)
        {
           TimeSpan offset = TimeSpan.FromSeconds(timeZoneOffsetSeconds);
            DateTime localTime = utcTime + offset;
            return localTime.ToString("HH:mm");
        }

    }

}