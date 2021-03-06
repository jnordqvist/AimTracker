using DSU22_Team4.Models.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Data
{
    public class AppDbContext: DbContext
    {    
        public DbSet <Athlete> Athlete { get; set; }
        public DbSet<TrainingSession> TrainingSession { get; set; }
        public DbSet<Sleep> Sleep { get; set; }
        public DbSet<Geometry> Geometry { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Shot> Shot { get; set; }
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

    }
}
