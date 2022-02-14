using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Dto
{
    public class DatasetsDto
    {
        public List<ValuesDto> Values {get; set;}

        public DatasetsDto()
        {
            Values = new List<ValuesDto>();
        }

    }
}
