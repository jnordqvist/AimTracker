using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class SessionDetailsController : Controller
    {
        private readonly IStatsDbRepository _statsdb;

        public SessionDetailsController(IStatsDbRepository statsdb)
        {
            _statsdb = statsdb;
        }

        public async Task <IActionResult> Index(string id)
        {
            await Task.Delay(0);
            var trainingsession =  _statsdb.GetTrainingSession(id);
            var sessionDetailViewModel = new SessionDetailViewModel(trainingsession);

            return View(sessionDetailViewModel);
        }
    }
}