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
        public DbSet <TrainingSession> TrainingSessions { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

    }
}
