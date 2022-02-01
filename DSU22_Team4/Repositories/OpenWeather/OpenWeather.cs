using DSU22_Team4.Infrastructure;
using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories.OpenWeather
{
    public class OpenWeather : IOpenWeather
    {
        private readonly IApiClient _client;
        private readonly string _apikey;
        public OpenWeather(IApiClient client, string apiKey)
        {
            _client = client;
            _apikey = apiKey;
        }

        public async Task<WeatherInfoDto> GetWeatherByPointAndTimeAsync(double lat, double lon, DateTime date)
        {
            var time = ((DateTimeOffset)date).ToUnixTimeSeconds();
            var res = await _client.GetAsync<WeatherInfoDto>($"http://api.openweathermap.org/data/2.5/onecall/timemachine?lat=60.99&lon=30.9&dt={time}&units=metric&appid={_apikey}");
            return res;
        }
    }
}
