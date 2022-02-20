using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Geometry
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Geometry(GeometryDto geometryDto)
        {
            Id = geometryDto.Id;
            Lat = geometryDto.Coordinates[0];
            Lon = geometryDto.Coordinates[1];
        }
        public Geometry()
        {

        }



    }
}
