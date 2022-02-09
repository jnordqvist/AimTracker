﻿using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class HomeViewModel
    {
        public Athlete Athlete { get; set; }

 
        //public TrainingSession Session { get; set; }
        //public DateTime Date { get; set; }
        //public ICollection<Serie> Series { get; set; }

        public WeatherInfoDto Weather { get; set; }
        public List<TrainingSessionDto> TrainingSessions { get; set; }
        


        public HomeViewModel(Athlete athlete, List<TrainingSessionDto> trainingSessions, WeatherInfoDto weather)
        {
            Athlete = athlete;
            //CalculateSeriesHitPercentage(Series.FirstOrDefault());
          
             GetSessionTotalHitPercentage(athlete.TrainingSession.FirstOrDefault());
            GetSessionAverageHitPercentage(athlete.TrainingSession.FirstOrDefault());

            Weather = weather;
           TrainingSessions = trainingSessions;
        }
        public HomeViewModel()
        {

        }


        public string GetSeriesHitPercentage(SerieDto serie)
        {
            string result = $"{CalculateHitPercentage(serie) * 100}%";
            return result;
        }

        public double CalculateHitPercentage(SerieDto serie)
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

        public string GetSessionAverageHitPercentage(TrainingSessionDto session)
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


        public int GetTotalNumOfShots(TrainingSessionDto session)

        {
            int shots = 0;
            foreach (var serie in trainingsession.Results)
            {
                foreach (var shot in serie.Shots)
                {
                    shots += 1;
                }
            }
            return shots;
        }


        public int GetTotalNumOfHits(TrainingSessionDto session)

        {
            int hits = 0;
            foreach (var serie in trainingsession.Results)
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

        public string GetSessionTotalHitPercentage(TrainingSessionDto session)
        {
            int shots = GetTotalNumOfShots(session);
            int hits = GetTotalNumOfHits(session);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 2);
            return $"{hitPercentage}%";
        }

        public string GetSessionTotalHitPercentageRounded(TrainingSessionDto session)
        {
            int shots = GetTotalNumOfShots(session);
            int hits = GetTotalNumOfHits(session);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100),0);
            return $"{hitPercentage}";
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
