using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using DSU22_Team4.Repositories.OpenWeather;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class AddDataController : Controller
    {
        private readonly IStatsDbRepository _db;
        private readonly IRepository _repository;
        private readonly IOpenWeather _weather;

        private readonly Athlete _athlete;

        public AddDataController(IStatsDbRepository db, IRepository repository, IOpenWeather weather, Athlete athlete)
        {
            _db = db;
            _repository = repository;
            _weather = weather;
            _athlete = athlete;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Success(AddDataViewModel model)
        {
            var sleep = new Sleep()
            {
                SleepTime = model.SleepTime,
                AwakeTime = model.AwakeTime,
                Quality = model.Quality
            };
            
            var res = await _repository.GetAimTrackerData();
            var aimTrackerData = res.FirstOrDefault();

            var timeStamp = aimTrackerData.Date;
            var lat = aimTrackerData.Geometry.Coordinates[0];
            var lon = aimTrackerData.Geometry.Coordinates[1];
            try
            {
                var weatherData = await _weather.GetWeatherByPointAndTimeAsync(lat, lon, timeStamp);
                //res.FirstOrDefault().Weather = weatherData.Current;
            }
            catch
            {

            }

            
            //var athlete = _db.GetAthleteWithSleep("1");
            var athlete = _db.GetAthleteById("1");
            _db.AddSleepToAthlete(athlete, sleep);
            athlete = _db.GetSleep("1", new DateTime(2022, 02, 02, 08, 00, 00));



            //athlete.TrainingSession.Add(res.FirstOrDefault());

            //athlete.Name = "Pelle Andersson";
            var a = new Athlete(){ Id = "1", TrainingSession = res};
            //_db.UpdateAthlete(athlete);

            return View(new SuccessViewModel(athlete));
        }

        

    }
}
