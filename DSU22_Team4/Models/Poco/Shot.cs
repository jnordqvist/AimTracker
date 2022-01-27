using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Shot
    {    
        public int Id { get; set; }
        public int ShotNr { get; set; }
        public string  TimeToFire { get; set; }

        public string Result { get;  }

        
    }
}
