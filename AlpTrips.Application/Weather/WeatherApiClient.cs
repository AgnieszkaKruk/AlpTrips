using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Globalization;

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

        public async Task<ForecastData> GetWeatherForecastAsync(string latitude, string longitude)
        {
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={latitude},{longitude}&days=10";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                ForecastData forecastData = ParseForecastData(json);
                return forecastData;
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

        private ForecastData ParseForecastData(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject(json);

            ForecastData forecastData = new ForecastData();
            var forecastArray = jsonObject.forecast.forecastday;
            forecastData.Forecast = new WeatherData[forecastArray.Count];

            for (int i = 0; i < forecastArray.Count; i++)
            {
                dynamic forecastItem = forecastArray[i];

                WeatherData weatherData = new WeatherData();
                string dateString = forecastItem.date.ToString();
                string format = "yyyy-MM-dd";
                DateTime date;
                DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                weatherData.Date = date;
               
                weatherData.MaxTemperature = (double)forecastItem.day.maxtemp_c;
                weatherData.MinTemperature = (double)forecastItem.day.mintemp_c;
                weatherData.Condition = (string)forecastItem.day.condition.text;
                weatherData.IconUrl = (string)forecastItem.day.condition.icon;
                weatherData.WindStrength = (double)forecastItem.day.maxwind_kph;
                weatherData.Precipitation = (double)forecastItem.day.totalprecip_mm;

                forecastData.Forecast[i] = weatherData;
            }

            return forecastData;
        }

    }
}


