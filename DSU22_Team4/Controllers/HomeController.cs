using DSU22_Team4.Models;
using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
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
        private readonly IStatsDbRepository _repo;
        private IRepository repository;
        private List<TrainingSession> trainingSessions;

        public HomeController(ILogger<HomeController> logger, IStatsDbRepository repo, IRepository repository)
        {
            _logger = logger;
            _repo = repo;
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            await Task.Delay(0);
            var athlete = _repo.GetAthleteById("1");
            try
            {
                trainingSessions = await repository.GetTrainingSessions();
                //var model = new HomeViewModel(athlete, trainingSessions);
                //return View(model);
            }
            catch (System.Exception)
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "Failed to connect to api");
                return View(model);
                throw;
            }

            return View(new HomeViewModel(athlete, trainingSessions));
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
}
