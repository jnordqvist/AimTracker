using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Shot
    {
        public int Id { get; set; }
        public int ShotNr { get; set; }
        public int HeartRate { get; set; }
        public string Result { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string TimeToFire { get; set; }
        public virtual int SerieId {get; set;}


        public Shot(ShotDto shot)
        {
            Id = shot.Id;
            ShotNr = shot.ShotNr;
            HeartRate = shot.HeartRate;
            Result = shot.Result;
            X = shot.FiringCoords.X;
            Y = shot.FiringCoords.Y;
            TimeToFire = shot.TimeToFire;
        }
        public Shot()
        {

        }
    }
}
