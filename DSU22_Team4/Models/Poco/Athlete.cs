using DSU22_Team4.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Athlete 
    {
        public string Id { get; set; }
        public string FullName { get; set; } 
        public string Image { get; set; }
        public string MaxHeartRate { get; set; }
       

        //public virtual ICollection<TrainingSession> TrainingSession { get; set; }
        public virtual ICollection<Sleep> Sleep { get; set; }

        public Athlete(AthleteDto athleteDto)
        {
            Id = athleteDto.IbuId;
            Image = athleteDto.Image;
            MaxHeartRate = athleteDto.MaxHeartRate;
            FullName = athleteDto.FullName;
        }

        public Athlete ()
        {

        }


    }
}
