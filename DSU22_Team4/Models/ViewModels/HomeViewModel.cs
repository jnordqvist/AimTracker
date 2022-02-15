using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class HomeViewModel
    {
        public Athlete Athlete { get; set; }
        public WeatherInfoDto Weather { get; set; }
        public List<TrainingSession> TrainingSessions { get; set; }
        public List <Serie> Series { get; set; }
        public TrainingSessionDto TrainingSessionDto{ get; set; }
        
         [DisplayFormat (DataFormatString= "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
         [DataType (DataType.Date)]
        public DateTime Date { get; set; }
        public HomeViewModel(Athlete athlete, List<TrainingSession> trainingSessions, WeatherInfoDto weather)
        {
           Athlete = athlete;
           GetSessionTotalHitPercentage(trainingSessions.FirstOrDefault());
           GetSessionAverageHitPercentage(trainingSessions.FirstOrDefault());
           Weather = weather;
           TrainingSessions= trainingSessions;

        }
        public HomeViewModel()
        {

        }

        public string GetSeriesHitPercentage(Serie serie)
        {
            string result = $"{CalculateHitPercentage(serie) * 100}%";
            return result;
        }

        public double CalculateHitPercentage(Serie serie)
        {
            double counter = 0;
            foreach (var shot in serie.Shots)
            {
                if (shot.Result == "hit")
                {
                    counter += 1;
                }
            }
            double temp = (double)serie.Shots.Count;
            double hitPercentage = counter / temp;
            return hitPercentage;
        }

        public string GetSessionAverageHitPercentage(TrainingSession session)
        {
            double hitPercentage = 0;
            foreach (var serie in session.Results)
            {
                hitPercentage += CalculateHitPercentage(serie);
            }
            double series = (double)session.Results.Count();
            double result = hitPercentage / series;
            return $"{result * 100}%";
        }

        public int GetTotalNumOfShots(TrainingSession session)
        {
            int shots = 0;
            foreach (var serie in session.Results)
            {
                foreach (var shot in serie.Shots)
                {
                    shots += 1;
                }
            }
            return shots;
        }

        public int GetTotalNumOfHits(TrainingSession session)

        {
            int hits = 0;
            foreach (var serie in session.Results)
            {
                foreach (var shot in serie.Shots)
                {
                    if (shot.Result == "hit")
                    {
                        hits += 1;
                    }
                }
            }
            return hits;
        }

        public string GetSessionTotalHitPercentage(TrainingSession session)
        {
            int shots = GetTotalNumOfShots(session);
            int hits = GetTotalNumOfHits(session);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 2);
            return $"{hitPercentage}%";
        }

        public string GetSessionTotalHitPercentageRounded(TrainingSession session)
        {
            int shots = GetTotalNumOfShots(session);
            int hits = GetTotalNumOfHits(session);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100),0);
            return $"{hitPercentage}";
        }

        public double CalculateAverageXCoord(Serie serie)
        {
            List<double> listOfXCoords = new List<double>();
            double averageX;
            foreach (var shot in serie.Shots)
            {
                listOfXCoords.Add(shot.X);
            }
            averageX = listOfXCoords.Average();
            return averageX;
        }

        public double CalculateAverageYCoord(Serie serie)
        {
            List<double> listOfYCoords = new List<double>();
            double averageY;
            foreach (var shot in serie.Shots)
            {
                listOfYCoords.Add(shot.Y);
            }
            averageY = listOfYCoords.Average();
            return averageY;
        }
    }  
}
