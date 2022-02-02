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
        private IRepository _repository;
        private IOpenWeather _weather;
        

        public AddDataController(IStatsDbRepository db, IRepository repository, IOpenWeather weather)
        {
            _db = db;
            _repository = repository;
            _weather = weather;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Success()
        {
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

            //var athlete = _db.GetAthleteById("1");

            //athlete.TrainingSession.Add(res.FirstOrDefault());

            //athlete.Name = "Pelle Andersson";
            var a = new Athlete(){ Id = "1", TrainingSession = res};
            //_db.UpdateAthlete(athlete);

            var athlete = _db.GetAthleteById("1");
            return View(new SuccessViewModel(athlete));
        }
    }
}
