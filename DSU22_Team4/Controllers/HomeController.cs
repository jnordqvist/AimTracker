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
        #region privatefields

        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _dbrepo;
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOpenWeather _weather;
        #endregion

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
            DateTime date = DateTime.Now;
            DateTime dateEndDate = date.AddDays(-1);
            DateTime dateStartDate = dateEndDate.AddDays(-4);
            string endDate = dateEndDate.ToString("yyMMdd");
            string startDate = dateStartDate.ToString("yyMMdd");
            var athlete = _dbrepo.GetAthleteById(athleteId);
            await FillDatabaseWithSessions(athlete, startDate, endDate);
            await GetAndFillDatabaseWithLatestTrainingSession(athlete);
            var trainingSessions = _dbrepo.GetTrainingSessions(athlete.Id);
            var weather = new WeatherInfoDto();
            try
            {
                weather = await _weather.GetWeatherByPointAndTimeAsync(63.190586, 14.658355, new DateTime(2022, 02, 13, 18, 38, 00));
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

        public async Task GetAndFillDatabaseWithLatestTrainingSession(Athlete athlete)
        {  
            var data= await _repository.GetLatestTrainingSession(athlete.Id);
            _dbrepo.AddLatestTrainingSession(data);           
        }   
    }
    }

              