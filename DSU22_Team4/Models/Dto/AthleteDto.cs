using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Dto
{
    public class AthleteDto
    {
        public string IbuId  { get; set; }
        public string FullName { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Contry { get; set; }
        public string Nat { get; set; }
        public string GenderId{ get; set; }
        public string MaxHeartRate { get; set; }
        public List <string> StatSeasons { get; set; }
        public List<string> StatShootingProne { get; set; }
        public List<string> StatShootinStanding { get; set; }

       
}
}
