using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class SessionDetailViewModel
    {
        public List<Serie> Series{ get; set; }

        public SessionDetailViewModel(List<Serie> series)
        {
            Series = series;
        }

    }
}
