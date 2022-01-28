using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Athlete : User
    {
        public virtual ICollection<TrainingSession> TrainingSession { get; set; }
    }
}
