using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class ValuesViewModel
    {
        public DatasetsDto Datasets {get; set;}

        public ValuesViewModel(DatasetsDto datasets)
        {

        }
    }
}
