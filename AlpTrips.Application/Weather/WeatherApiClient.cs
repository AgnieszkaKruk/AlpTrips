using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Weather
{
    public class WeatherApiClient
    {
        private string apiKey = "24456521918244a590a194429231506";
        private HttpClient client;

        public WeatherApiClient()
        {
            client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherDataAsync(string latitude, string longitude)
        {
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={latitude},{longitude}&days=1";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = ParseWeatherData(json);
                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        private WeatherData ParseWeatherData(string json)
        {

            dynamic jsonObject = JsonConvert.DeserializeObject(json);

            WeatherData weatherData = new WeatherData();
           // weatherData.Date = DateTime.ParseExact(jsonObject.forecast.forecastday[0].date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string dateString = jsonObject.forecast.forecastday[0].date;
            string format = "yyyy-MM-dd";
            DateTime date;
            DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
           
                weatherData.Date = date;
            
            weatherData.MaxTemperature = (double)jsonObject.forecast.forecastday[0].day.maxtemp_c;
            weatherData.MinTemperature = (double)jsonObject.forecast.forecastday[0].day.mintemp_c;
            weatherData.Condition = (string)jsonObject.forecast.forecastday[0].day.condition.text;
            weatherData.IconUrl = (string)jsonObject.forecast.forecastday[0].day.condition.icon;
            weatherData.WindStrength = (double)jsonObject.forecast.forecastday[0].day.maxwind_kph;
            weatherData.Precipitation = (double)jsonObject.forecast.forecastday[0].day.totalprecip_mm;

            return weatherData;
        }

    }
}


