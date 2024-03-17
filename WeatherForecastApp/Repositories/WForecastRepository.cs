using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WeatherForecastApp.OpenWeatherMap_Model;

namespace WeatherForecastApp.Repositories
{
    public class WForecastRepository : IWForecastRepository
    {
        private readonly RestClient _restClient;
        public WeatherResponse GetForecast(string city)
        {
            string APP_ID = Configuration.Values.OPENT_WEATHER_APP_ID;
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={APP_ID}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content?.ToObject<WeatherResponse>();
            }
            else
            {
                return null;
            }
        }
        public async Task<List<string>> GetCities(string country)
        {
            var client = new RestClient("https://countriesnow.space/api/v0.1/countries/cities");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var requestBody = new Dictionary<string, string>
            {
                { "country", country }
            };
            request.AddJsonBody(requestBody);
            var response = await client.ExecuteAsync(request);
            
            if (response.IsSuccessful)
            {
                var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
                if (responseData.TryGetValue("data", out var data) && data is JToken dataToken)
                {
                    // Deserialize the 'cities' array directly from the 'data' object
                    var cities = dataToken.ToObject<List<string>>();
                    return cities;
                }
            }
            
            // If API call fails or data structure is unexpected, return an empty list
            return new List<string>();
        }

    }
}