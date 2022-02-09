using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Serie
    {
        public int Id { get; set; }
        public string Stance { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<ShotDto> Shots { get; set; }
        public double AverageYCoord { get; set; }
        public double AverageXCoord { get; set; }

        public Serie(SerieDto serie)
        {
            Id = serie.Id;
            Stance = serie.Stance;
            DateTime = serie.DateTime;
            //Shots = serie.Shots;
            AverageYCoord = CalculateAverageYCoord(serie);
            AverageXCoord = CalculateAverageXCoord(serie);
        }
        public Serie()
        {
            
        }

        public double CalculateAverageXCoord(SerieDto serie)
        {
            List<double> listOfXCoords = new List<double>();
            double averageX;
            foreach (var shot in serie.Shots)
            {
                listOfXCoords.Add(shot.FiringCoords.X);
            }
            averageX = listOfXCoords.Average();
            return averageX;
        }

        public double CalculateAverageYCoord(SerieDto serie)
        {
            List<double> listOfYCoords = new List<double>();
            double averageY;
            foreach (var shot in serie.Shots)
            {
                listOfYCoords.Add(shot.FiringCoords.Y);
            }
            averageY = listOfYCoords.Average();
            return averageY;
        }
    }
}
