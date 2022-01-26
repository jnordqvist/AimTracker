using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public  string Location { get; set; }
        public int IbuId { get; set;  }

        public ICollection<Serie>  Series { get; set; }

    }
}
