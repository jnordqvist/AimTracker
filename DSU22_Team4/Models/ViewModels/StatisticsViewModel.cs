using DSU22_Team4.Models.Poco;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public Athlete Athlete { get; set; }
        [Display(Name = "Training Session")]
        public TrainingSession TrainingSession { get; set; }
        //public IEnumerable<SelectListItem> DropDownTrainingSessions { get; set; }
        public int Intensity { get; set; }
        public StatisticsViewModel(Athlete athlete, TrainingSession session , int intensity)
        {
            Athlete = athlete;
           // DropDownTrainingSessions = selectListItems;
            TrainingSession = session;
            Intensity = AverageHeartRateForSession(session, athlete);
        }

        public int GetHeartrateForSession(TrainingSession session)
        { 
            {
                int heartrates = 0;
                int shotcounter = 0;

                foreach (var serie in session.Results)
                {
                    foreach (var shot in serie.Shots)
                    {
                        heartrates += shot.HeartRate;
                        shotcounter++;
                    }
                }
                int averageHR = heartrates / shotcounter;
                return averageHR;
            }
        }

        public int AverageHeartRateForSession(TrainingSession session, Athlete athlete)
        {
            int maxHR = int.Parse(athlete.MaxHeartRate);
            int heartrateForSession = GetHeartrateForSession(session);
            double avHRdbl = Math.Round((((double)heartrateForSession / (double)maxHR) * 100), 0);
            int avHR = (int)avHRdbl;
            return avHR;
        }
        //double hitPercentage = Math.Round((((double)hits / (double)shots) * 100), 2);
    }
}
