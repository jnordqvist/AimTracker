using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Athlete : User
    {
        public string IbuId { get; set; }
        public virtual ICollection<TrainingSession> TrainingSession { get; set; }

        public virtual ICollection <Sleep> Sleep { get; set;}

        public Athlete(AthleteDto athleteDto)
        {
            IbuId = athleteDto.IbuId;   
        }

        public Athlete ()
        {

        }


    }
}
