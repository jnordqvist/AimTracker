using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatsDbRepository _statsdb;

        public StatisticsController(IStatsDbRepository statsdb)
        {
            _statsdb = statsdb;
        }
        public async Task<IActionResult> Index(string id)
        {
            await Task.Delay(0);
            var athlete = _statsdb.GetAthleteById(id);
            var statisticsViewModel = new StatisticsViewModel(athlete);

            return View(statisticsViewModel);
        }
    }
}
