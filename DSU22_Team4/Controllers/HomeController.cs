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
        private readonly IStatsDbRepository _dbrepo;
        private IRepository _repository;
        private List<TrainingSessionDto> trainingSessions;
        private List<TrainingSessionDto> sessions;
        private readonly UserManager<IdentityUser> _userManager;
        private IOpenWeather _weather;
        private List<AthleteDto> athletes;
        public HomeController(ILogger<HomeController> logger, IStatsDbRepository dbrepo, IRepository repository, UserManager<IdentityUser> userManager, IOpenWeather weather)
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
            //await FillAimTrackerDatabase();
            var weather = new WeatherInfoDto();
            try
            {
                trainingSessions = await _repository.GetAimTrackerData();
                sessions = await _repository.GetAimTrackerDataByDate(athleteId, startDate, endDate);
                athletes = await _repository.GetAthletesAsync();
                weather = await _weather.GetWeatherByPointAndTimeAsync(63.190586, 14.658355, new DateTime(2022, 02, 04, 18, 38, 00));
            }

            catch (System.Exception)
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "Failed to connect to api");
                return View(model);
                throw;
            }
            //return View();
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
            
            foreach (var a in data)
            {
                if (data.Count == 0)
                {
                    var athlete = new Athlete();
                    athlete.Id = a.IbuId;
                    _repository.SeedAthletes(athlete);
                }
            }
           
        }
    }


        //public HomeController(IRepository repository)
        //{
        //    this.repository = repository;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        trainingSessions = await repository.GetTrainingSessions();
        //        var model = new HomeViewModel(trainingSessions);
        //        return View(model);
        //    }
        //    catch (System.Exception)
        //    {
        //        var model = new HomeViewModel();
        //        ModelState.AddModelError(string.Empty, "Failed to connect to api");
        //        return View(model);
        //        throw;
        //    }
        //}


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}


    }

