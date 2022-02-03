using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Sleep
    {
        public int Id { get; set; }

        public DateTime SleepTime  { get; set;}

        public DateTime AwakeTime { get; set; }

        public string Quality { get; set; }
        

    }
}
