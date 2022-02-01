using DSU22_Team4.Data;
using DSU22_Team4.Models.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class StatsDbRepository : IStatsDbRepository
    {
        private readonly AppDbContext _db;
       
        public StatsDbRepository(AppDbContext db)
        {
            _db = db;
            GetAthleteById("1");
        }

        public Athlete GetAthleteById(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Where(x => x.Id == id)
                 .Include(t => t.TrainingSession)
                 .ThenInclude(s => s.Series)
                 .ThenInclude(z => z.Shots);

            return athlete.FirstOrDefault();
        }

        public Task<Athlete> GetAthleteAsync()
        {
            throw new NotImplementedException();
        }

       
    }
}
