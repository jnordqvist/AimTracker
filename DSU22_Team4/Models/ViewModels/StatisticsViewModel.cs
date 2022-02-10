using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public Athlete Athlete { get; set; }
        public StatisticsViewModel(Athlete athlete)
        {
            Athlete = athlete;
        }
    }
}
