using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories.OpenWeather
{
    public interface IOpenWeather
    {
        Task<WeatherInfoDto> GetWeatherByPointAndTimeAsync(double lat, double lon, DateTime date);
    }
}
