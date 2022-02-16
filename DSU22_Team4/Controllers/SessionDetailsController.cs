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
        private readonly IDbRepository _statsdb;
        int count = 1;

        public SessionDetailsController(IDbRepository statsdb)
        {
            _statsdb = statsdb;
        }

        public async Task<IActionResult> Index(string id)
        {
            await Task.Delay(0);
            var series = _statsdb.GetResultsByTrainingSessionsId(id);
            var sessionDetailViewModel = new SessionDetailViewModel(series);

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