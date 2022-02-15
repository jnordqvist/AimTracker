using DSU22_Team4.Data;
using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _db;
       
        public DbRepository(AppDbContext db)
        {
            _db = db;
            //GetAthleteById("1");
        }

        public Athlete GetAthleteById(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Include(i => i.Sleep);

            return athlete.FirstOrDefault();
        }

        //public Athlete GetSleep(string id, DateTime date)
        //{
        //    var athlete = _db.Athlete.Where(x => x.Id == id)
        //        .Include(s => s.Sleep.Where(d => d.AwakeTime.Date == date.Date)
        //        .FirstOrDefault();

        //    return athlete;
        //}


        public void Seed(Athlete a)
        {
            _db.Add(a);
            _db.SaveChanges();
        }

        public Athlete GetAthleteWithSleep(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Where(x => x.Id == id)
                 .Include(s => s.Sleep).FirstOrDefault();

            return athlete;
        }

        //public void UpdateAthlete(Athlete athlete)
        //{
        //    var session = athlete.TrainingSession.FirstOrDefault();
        //    _db.Update(session);
        //    _db.SaveChanges();
        //}

        public void AddSleepToAthlete(Athlete athlete, Sleep sleep)
        {
            athlete.Sleep.Add(sleep);
            _db.Update(athlete);
            _db.SaveChanges();
        }

        public Task<Athlete> GetAthleteAsync()
        {
            throw new NotImplementedException();
        }

        public TrainingSession GetTrainingSession(string ibuId)
        {
            var trainingSession= _db.TrainingSession.Where(x => x.IbuId == ibuId).FirstOrDefault();
            return trainingSession;
        }

        public Serie GetSerie (int id)
        {
            var serie = _db.Serie.Where(x => x.Id == id).FirstOrDefault();
            return serie;
        }

        public List<Shot> GetShotsBySerieId(int id)
        {
            List<Shot> shots = _db.Shot.Where(x => x.SerieId == id).ToList();
            return shots;
        }


        public List<TrainingSession> GetTrainingSessions(string ibuId)
        {
            var trainingSessions = _db.TrainingSession.Where(x => x.IbuId == ibuId).OrderByDescending(y => y.Date).Take(5).Include(x => x.Results)
                .ThenInclude(y => y.Shots);
            return trainingSessions.ToList();
        }

        public List<TrainingSession> GetPreviousTrainingSessions(string ibuId, string startDate, string endDate)
        {
            List<TrainingSession> trainingSessions = new List<TrainingSession>();
            foreach (var ts in trainingSessions)
            {
                var trainingSession = _db.TrainingSession.Where(x => x.IbuId == ibuId);
                trainingSessions.Add(ts);
            }
            return trainingSessions;
        }

        public void AddLatestTrainingSession(TrainingSessionDto trainingSessionDto)
        {
            var trainingsession = new TrainingSession(trainingSessionDto);
            _db.Add(trainingsession);
            _db.SaveChanges();
        }

        public void SeedTrainingSessions(List<TrainingSessionDto> trainingSessions)
        {  
            foreach (var trainingsession in trainingSessions)
            {
                if (!_db.TrainingSession.Any(x => x.Id == trainingsession.Id))
                {
                    var session = new TrainingSession(trainingsession);
                    
                    _db.Add(session);
                }
            }
            _db.SaveChanges();
        }

        public void SeedAthletes(List <AthleteDto> athletedto)
        {  //fyller på alla på en gång oavsett vem som loggar in. Fixa sen?
            foreach (var a in athletedto)
            {
                if (!_db.Athlete.Any(x => x.Id == a.IbuId))
                {
                    var athlete = new Athlete(a);
                    _db.Add(athlete);
                }

            }
  
           
            _db.SaveChanges();
        }

        public int[] GetStatisticsValues(string ibuId, ValuesDto values)
        {
            var data = _db.TrainingSession.Where(x => x.IbuId == ibuId).Include(y => y.Results).ThenInclude(z => z.Shots);
            data.Select(a => a.Results.Select(b => b.Shots.Select(c => c.HeartRate))).ToList();
            return values.Data;
        }

        //public void SeedTrainingSessions( List <TrainingSession> trainingSessions)
        //{
        //    f
        //    _db.Add(trainingSessions);
        //    _db.SaveChanges();
        //}
    }
}
