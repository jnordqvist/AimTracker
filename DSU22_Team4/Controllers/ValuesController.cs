using DSU22_Team4.Models.Dto;
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

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<DatasetsDto> Get()
        {
            await Task.Delay(0);

            string id = "BTSWE22803199001";


            ValuesDto values = new ValuesDto();

            values.Data = _dbrepo.GetStatisticsValues(id, values);
            values.BorderColor = "red";
            values.Fill = false;


            datasets.Values.Add(values);
            
            return datasets;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
