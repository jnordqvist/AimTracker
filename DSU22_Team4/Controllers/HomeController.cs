using DSU22_Team4.Models;
using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using DSU22_Team4.Repositories.OpenWeather;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _dbrepo;
        private IRepository _repository;
        private List<TrainingSession> trainingSessions;
        private readonly UserManager<IdentityUser> _userManager;
        private IOpenWeather _weather;
        private List<AthleteDto> athletes;
        public HomeController(ILogger<HomeController> logger, IDbRepository dbrepo, IRepository repository, UserManager<IdentityUser> userManager, IOpenWeather weather)
        {
            _logger = logger;
            _dbrepo = dbrepo;
            _repository = repository;
            _userManager = userManager;
            _weather = weather;
        }

        public async Task<IActionResult> Index()
        {
            await Task.Delay(0);
            await FillDataToAthlete();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            string athleteId = user.Id;
            string startDate = "220123";
            string endDate = "220206";
            
            var athlete = _dbrepo.GetAthleteById(user.Id);
            await FillDatabaseWithSessions(athlete, startDate, endDate);
            var trainingSessions = _dbrepo.GetTrainingSessions(athlete.Id);
            var weather = new WeatherInfoDto();
            try
            {
                weather = await _weather.GetWeatherByPointAndTimeAsync(63.190586, 14.658355, new DateTime(2022, 02, 08, 18, 38, 00));
            }

            catch (System.Exception)
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "Failed to connect to api");
                return View(model);
                throw;
            }
            return View(new HomeViewModel(athlete, trainingSessions, weather));
        }

        //public async Task FillAimTrackerDatabase()
        //{
        //    //var data = await _repository.GetAimTrackerData();
        //    var athlete = new Athlete()
        //    {
                
        //        TrainingSession = data

        //    };
        //    _repo.Seed(athlete);
        //}

        public async Task FillDataToAthlete()
        {
            var data = await _repository.GetAthletesAsync();

            _dbrepo.SeedAthletes(data);
           
        }

        public async Task FillDatabaseWithSessions(Athlete athlete, string startDate, string endDate)
        {
            var data = await _repository.GetTrainingSessionsByDate(athlete.Id, startDate, endDate);

            _dbrepo.SeedTrainingSessions(data);    
        }
    }
    }

              