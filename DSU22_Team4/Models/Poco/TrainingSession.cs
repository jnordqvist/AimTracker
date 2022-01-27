using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class TrainingSession
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public  string Location { get; set; }
        public string IbuId { get; set;  }

        public ICollection<Serie>  Series { get; set; }

    }
}
