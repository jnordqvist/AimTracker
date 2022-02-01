using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Dto
{
    public class WeatherInfoDto
    {
        public string Lat { get; set; }
        public WeatherCurrentDto Current { get; set; }
    }
}
