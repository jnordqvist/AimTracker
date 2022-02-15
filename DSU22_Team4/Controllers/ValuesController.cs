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
    }
}
