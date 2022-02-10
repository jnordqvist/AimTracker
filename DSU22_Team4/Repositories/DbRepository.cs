﻿using DSU22_Team4.Data;
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

        public void AddLatestTrainingSession(TrainingSession trainingSession)
        {
            _db.Add(trainingSession);
            _db.SaveChanges();
        }

        public void SeedTrainingSessions(List<TrainingSessionDto> trainingSessions)
        {  
            foreach (var s in trainingSessions)
            {
                var trainingsession = new TrainingSession
                {
                    Id = s.Id,
                    IbuId = s.IbuId,
                    Date = s.Date,
                    Geometry = s.Geometry,
                    Location = s.Location,
                    Results = s.Results

                   
                

            };
          
                _db.Add(trainingsession);
                
            }
            _db.SaveChanges();
        }

        public void SeedAthletes(Athlete athlete)
        {
            _db.Add(athlete);
            _db.SaveChanges();
        }

        //public void SeedTrainingSessions( List <TrainingSession> trainingSessions)
        //{
        //    f
        //    _db.Add(trainingSessions);
        //    _db.SaveChanges();
        //}
    }
}
