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
        public Athlete newAthlete;
        public TrainingSession Session { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Serie> Series { get; set; }


        public List<TrainingSession> allTrainingSessions { get; set; }


        public HomeViewModel(Athlete athlete, List<TrainingSession> trainingSessions)
        {
            Athlete = athlete;
           //CalculateSeriesHitPercentage(Series.FirstOrDefault());
             GetSessionTotalHitPercentage(athlete.TrainingSession.FirstOrDefault());
            GetSessionAverageHitPercentage(athlete.TrainingSession.FirstOrDefault());
            allTrainingSessions = trainingSessions;
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
            foreach (var serie in session.Series)
            {
                hitPercentage += CalculateHitPercentage(serie);
            }
            double series = (double)session.Series.Count();
            double result = hitPercentage / series;
            return $"{result * 100}%";
        }

        public int GetTotalNumOfShots(TrainingSession session)
        {
            int shots = 0;
            foreach (var serie in session.Series)
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
            foreach (var serie in session.Series)
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
    }
}
