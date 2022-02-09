using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Shot
    {
        public int Id { get; set; }
        public int HeartRate { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Shot(ShotDto shot)
        {
            Id = shot.Id;
            HeartRate = shot.HeartRate;
            X = shot.FiringCoords.X;
            Y = shot.FiringCoords.Y;
        }
        public Shot()
        {

        }
    }
}
