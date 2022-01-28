using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class Serie
    {
        public int Id { get; set; }

        public string Stance { get; set; }

        public DateTime DateTime { get; set; }

        public virtual ICollection <Shot> Shots { get; set; }
        
    }
}
