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
       

        #region ctor
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
        #endregion

        #region calculatemethods
        /// <summary>
        /// Calculates hit percentage for all shots in a session
        /// </summary>
        /// <param name="serie"></param>
        /// <returns> hitpercentage</returns>
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
        /// <summary>
        /// Calculates average hit percentage
        /// </summary>
        /// <param name="trainingsession"></param>
        /// <returns>average hit percentage as a string</returns>
        public string GetSessionAverageHitPercentage(TrainingSession trainingsession)
        {
            double hitPercentage = 0;
            foreach (var serie in trainingsession.Results)
            {
                hitPercentage += CalculateHitPercentage(serie);
            }
            double series = (double)trainingsession.Results.Count();
            double result = hitPercentage / series;
            return $"{result * 100}%";
        }
        /// <summary>
        /// Gets the total number of shots
        /// </summary>
        /// <param name="session"></param>
        /// <returns>Total number of shots</returns>
        public int GetTotalNumOfShots(TrainingSession trainingsession)
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
        /// <summary>
        /// Get total number of hits
        /// </summary>
        /// <param name="session"></param>
        /// <returns> the total number of hits</returns>
        public int GetTotalNumOfHits(TrainingSession trainingsession)
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
        /// <summary>
        /// get a sessions total hit percentage
        /// </summary>
        /// <param name="trainingsession"></param>
        /// <returns>Hit percentage</returns>
        public string GetSessionTotalHitPercentage(TrainingSession trainingsession)
        {
            int shots = GetTotalNumOfShots(trainingsession);
            int hits = GetTotalNumOfHits(trainingsession);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 2);
            return $"{hitPercentage}%";
        }
        /// <summary>
        /// Round the sessions total hitpercentage
        /// </summary>
        /// <param name="trainingsession"></param>
        /// <returns></returns>
        public string GetSessionTotalHitPercentageRounded(TrainingSession trainingsession)
        {
            int shots = GetTotalNumOfShots(trainingsession);
            int hits = GetTotalNumOfHits(trainingsession);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100),0);
            return $"{hitPercentage}";
        }

        #endregion
    }
}
