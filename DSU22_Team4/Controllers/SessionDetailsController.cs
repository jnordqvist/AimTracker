using DSU22_Team4.Models.Poco;
using DSU22_Team4.Models.ViewModels;
using DSU22_Team4.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class SessionDetailsController : Controller
    {
        private readonly IDbRepository _db;
        private readonly UserManager<IdentityUser> _userManager;
       

        public SessionDetailsController(IDbRepository db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            await Task.Delay(0);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            string athleteId = user.Id;
            var athlete = _db.GetAthleteById(athleteId);
            var series = _db.GetResultsByTrainingSessionsId(id);
            var trainingsessions = _db.GetTrainingSessions(athleteId);
            var sessionDetailViewModel = new SessionDetailViewModel(series,trainingsessions,athlete);

            return View(sessionDetailViewModel);
        }

        //public ActionResult Get()
        //{

        //}
        [HttpPost]
        public ActionResult Next(SessionDetailViewModel sessionViewModel)
        {


            return Ok (sessionViewModel.SplitList(sessionViewModel.Series, sessionViewModel.NextPage));
        }
    }
}