using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models
{
    public  class City
    {
        [Display(Name = "City Name:")]
        public string Name {get; set;}
        [Display(Name = "Temperature in Celcius")]
        public float Temperature{get; set;}
        [Display(Name = "Temperature in Fahrenheit")]
        public float TemperatureInF {get;set;}
        [Display(Name = "Humidity")]
        public int Humidity{get; set;}
        [Display(Name = "Pressure")]
        public int Pressure{get; set;}
        [Display(Name = "Wind Speed:")]
        public float Wind{get; set;}
        [Display(Name = "Weather Condition:")]
        public string Weather{get; set;}
        [Display(Name = "Visibility")]
        public float Visibility{get;set;}
        [Display(Name ="Local Time")]
        public string LocalTime{get;set;}
    }
}