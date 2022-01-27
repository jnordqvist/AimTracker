using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class HomeViewModel
    {
        public TrainingSession Session { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Serie> Series { get; set; }
        public HomeViewModel(TrainingSession session)
        {
            Session = session;
            Series = session.Series;
            //Date = session.Date;
        }
    }
}
