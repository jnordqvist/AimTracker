using DSU22_Team4.Models.Poco;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        public TrainingSession SelectedTrainingSession { get; set; }
        public IEnumerable<SelectListItem> DropDownTrainingSessions { get; set; }
        public int Intensity { get; set; }
        public ShotCoords[] LatestShooting { get; set; }
        public ShotCoords[] ShootingAverage { get; set; }
        public StatisticsViewModel(Athlete athlete, TrainingSession session, List<Shot> shots, IEnumerable<SelectListItem> selectListItems)
        {
            Athlete = athlete;
            DropDownTrainingSessions = selectListItems;
            SelectedTrainingSession = session;
            Intensity = AverageHeartRateForSession(session, athlete);
            LatestShooting = GetShotCoordinatesInSeries(shots);
            ShootingAverage = GetHistoricShotCoordinateAverage(session);
        }

        public int GetHeartrateForSession(TrainingSession session)
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

        public ShotCoords[] GetShotCoordinatesInSeries(List<Shot> shots)
        {
            List<ShotCoords> shotCoordinates = new List<ShotCoords>();

            foreach (var shot in shots)
            {
                shotCoordinates.Add(new ShotCoords { x = shot.X, y = shot.Y });
            }
             
            return shotCoordinates.ToArray();
        }

        public ShotCoords[] GetHistoricShotCoordinateAverage(TrainingSession sessions)
        {
            ShotCoords shotCoordinates = new ShotCoords();
            List<ShotCoords> shotCoords = new List<ShotCoords>();
            double x = 0;
            double y = 0;
            foreach (var serie in sessions.Results)
            {
                x += serie.AverageXCoord;
                y += serie.AverageYCoord;
            };

            shotCoordinates.x = x / sessions.Results.Count();
            shotCoordinates.y = y / sessions.Results.Count();
            shotCoords.Add(shotCoordinates);
            return shotCoords.ToArray();
        }

        public int AverageHeartRateForSession(TrainingSession session, Athlete athlete)
        {
            int maxHR = int.Parse(athlete.MaxHeartRate);
            int heartrateForSession = GetHeartrateForSession(session);
            double avHRdbl = Math.Round((((double)heartrateForSession / (double)maxHR) * 100), 0);
            int avHR = (int)avHRdbl;
            return avHR;
        }
    }
}
