using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IDbRepository _statsdb;
        private IEnumerable<SelectListItem> GetTrainingSessions(Athlete athlete)
        {
            var ddtrainingsessions = _statsdb
                        .GetTrainingSessions(athlete.Id)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Date.ToString(),
                                    Text = x.Date.ToString()
                                });

            return new SelectList(ddtrainingsessions, "Value", "Text");
        }

        private TrainingSession getDefaultSession(string id)
        {
            var sessions = _statsdb.GetTrainingSessions(id);
            return sessions.FirstOrDefault();
        }

        public StatisticsController(IDbRepository statsdb)
        {
            _statsdb = statsdb;
        }

        public async Task<IActionResult> Index(string id)
        {
            await Task.Delay(0);
            var athlete = _statsdb.GetAthleteById(id);
            var sessions = GetTrainingSessions(athlete);
            var defaultSession = getDefaultSession(id);
            int intensity = _statsdb.TrainingSessionIntensity();
            var statisticsViewModel = new StatisticsViewModel(athlete, defaultSession, sessions, intensity);
           // statisticsViewModel.DropDownTrainingSessions = _statsdb.GetTrainingSessions(athlete.Id);

            return View(statisticsViewModel);
        }
    }
}
