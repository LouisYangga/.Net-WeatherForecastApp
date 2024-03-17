using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Models;
using WeatherForecastApp.OpenWeatherMap_Model;
using WeatherForecastApp.Repositories;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;
        private readonly IWForecastService _WForecastService;
        public WeatherForecastController(IWForecastRepository wForecastRepository, IWForecastService wForecastService)
        {
            _WForecastRepository = wForecastRepository;
            _WForecastService = wForecastService;
        }
        [HttpGet]
        public IActionResult SearchByCity()
        {
            SearchByCity viewModel = new SearchByCity();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("City","WeatherForecast", new {City = model.CityName});
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
            City viewModel = new City();
            if(weatherResponse !=null)
            {
                viewModel.Name = weatherResponse.Name;
                var celcius = weatherResponse.Main.Temp;//In celcius
                viewModel.Temperature = celcius;
                viewModel.TemperatureInF = _WForecastService.CelsiusToFahrenheit(celcius);
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Name;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
                viewModel.Visibility = weatherResponse.Visibility;
                DateTime utcTime = DateTime.UtcNow;
                viewModel.LocalTime = _WForecastService.ConvertToLocalTime(utcTime,weatherResponse.Timezone);
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<JsonResult> GetCities(string country)
        {
            // Call the repository method to get cities
            var cities = await _WForecastRepository.GetCities(country);
            return Json(cities);
        }
    }
}