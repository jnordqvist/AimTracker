using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class SessionDetailViewModel 
    {
        public List<Serie> Series { get; set; }

        public List <TrainingSession> TrainingSessions { get; set; }
        
        public TrainingSession TrainingSession { get; set; }

        public Athlete Athlete { get; set; }

        
        
        public SessionDetailViewModel(List<Serie> series, List <TrainingSession> trainingSessions, Athlete athlete)
        {
            Series = series;
            
            TrainingSessions = trainingSessions;
            TrainingSession = GetOneTrainingSession(trainingSessions);
            Athlete = athlete;
            DisplaySeriesInOrder(series);
            
           
        }

       

        public TrainingSession GetOneTrainingSession(List <TrainingSession> trainingsessions)
        {
            foreach (var session in trainingsessions)
            {
                return trainingsessions.Where(x => x.Id == session.Id).FirstOrDefault();
            }
            return null;
        }

     
        public List <Serie> DisplaySeriesInOrder(List <Serie> series) {

           
            return series.OrderByDescending(x => x.DateTime).ToList();
        }

    

      
        public int GetTotalNumOfShots(List <Serie> series)
        {
            int shots = 0;
            foreach (var serie in series)
            {
                foreach (var shot in serie.Shots)
                {
                    shots += 1;
                }
            }
            return shots;
        }

        public int GetTotalNumOfHits(List <Serie> series)
        {
            int hits = 0;
            foreach (var serie in series)
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

        public string GetSessionTotalHitPercentage(List <Serie> series)
        {
            int shots = GetTotalNumOfShots(series);
            int hits = GetTotalNumOfHits(series);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 2);
            return $"{hitPercentage}%";
        }

        public string GetSessionTotalHitPercentageRounded(List <Serie> series)
        {
            int shots = GetTotalNumOfShots(series);
            int hits = GetTotalNumOfHits(series);

            double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 0);
            return $"{hitPercentage}";
        }

 


    }
}
