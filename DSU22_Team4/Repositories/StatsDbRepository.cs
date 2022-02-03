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
            //GetAthleteById("1");
        }

        public Athlete GetAthleteById(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Where(x => x.Id == id)
                 .Include(t => t.TrainingSession.OrderByDescending(y => y.Date)/*.Take(5)*/)
                 .ThenInclude(s => s.Results)
                 .ThenInclude(z => z.Shots);

            return athlete.FirstOrDefault();
        }

        public void Seed(Athlete a)
        {
            _db.Add(a);
            _db.SaveChanges();
        }

        public void UpdateAthlete(Athlete athlete)
        {
            var session = athlete.TrainingSession.FirstOrDefault();
            _db.Update(session);
            _db.SaveChanges();
        }

        public Task<Athlete> GetAthleteAsync()
        {
            throw new NotImplementedException();
        }

        public  TrainingSession GetTrainingSession(string id)
        {
            
            var session = _db.TrainingSession.Where(x => x.Id == id).FirstOrDefault();
            return session;
        }
       
    }
}
