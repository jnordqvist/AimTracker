using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using DSU22_Team4.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSU22_Team4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        DatasetsDto datasets = new DatasetsDto();
        private readonly IDbRepository _dbrepo;

        public ValuesController(IDbRepository dbrepo)
        {
            _dbrepo = dbrepo;
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            string ibuid = "BTSWE12403199201";
            var shootings = _dbrepo.GetStandingShootingHistory(ibuid).Select(x => x.Results).ToList();

            double x;

            foreach (var item in shootings)
            {
                x = CalculateAverageXCoord(item.ToList());
            }
            
            List<Shot> shots = _dbrepo.GetShotsBySerieId(id);
            int[] heartRates = new int[5];
            int counter = 0;

            foreach (var shot in shots)
            {
                heartRates[counter] = shot.HeartRate;
                counter++;
            }
            return Ok(heartRates);
        }

        private ActionResult Json(int[] data)
        {
            throw new NotImplementedException();
        }


        //public List<Serie> GetProneShootingHistory(List<TrainingSession> shootingHistory)
        //{

        //    var shootings = shootingHistory.Select(x => x.Results.Where(y => y.Stance == "Prone")).ToList();

        //    return shootings;
        //}

        public double CalculateAverageXCoord(List<Serie> serie)
        {
            List<double> listOfXCoords = new List<double>();
            double averageX;

            foreach (var s in serie)
            {
                listOfXCoords.Add(s.AverageXCoord);
            }

            averageX = listOfXCoords.Average();
            return averageX;
        }

        public double CalculateAverageYCoord(Serie serie)
        {
            List<double> listOfYCoords = new List<double>();
            double averageY;
            foreach (var shot in serie.Shots)
            {
                listOfYCoords.Add(shot.Y);
            }
            averageY = listOfYCoords.Average();
            return averageY;
        }

    }
}
