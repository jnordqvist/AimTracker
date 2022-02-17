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
        #region privatefields
        private readonly AppDbContext _db;
        #endregion

        #region ctor
        public DbRepository(AppDbContext db)
        {
            _db = db;
           
        }
        #endregion

        #region athletemethods
        // Gets the atheltebyId from db.
        public Athlete GetAthleteById(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Include(i => i.Sleep);

            return athlete.FirstOrDefault();
        }

     
        //Seed athlete 
        public void Seed(Athlete a)
        {
            _db.Add(a);
            _db.SaveChanges();
        }


        public void SeedAthletes(List<AthleteDto> athletedto)
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


        #endregion

        #region trainingsessionmethods
        public TrainingSession GetTrainingSession(string ibuId)
        {
            var trainingSession= _db.TrainingSession.Where(x => x.IbuId == ibuId).FirstOrDefault();
            return trainingSession;
        }
        public List<TrainingSession> GetTrainingSessions(string ibuId)
        {
            var trainingSessions = _db.TrainingSession.Where(x => x.IbuId == ibuId).OrderByDescending(y => y.Date).Take(5).Include(x => x.Results)
                .ThenInclude(y => y.Shots);
            return trainingSessions.ToList();
        }
        public List<TrainingSession> GetStandingShootingHistory(string ibuId)
        {
            var shootings = _db.TrainingSession.Where(x => x.IbuId == ibuId).Include(x => x.Results.Where(y => y.Stance == "Standing")).ToList();

            return shootings;
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
        #endregion
        #region seriemethods
        public Serie GetSerie (int id)
        {
            var serie = _db.Serie.Where(x => x.Id == id).FirstOrDefault();
            return serie;
        }
        public List<Serie> GetResultsByTrainingSessionsId(string id)
        {
            List<Serie> series = _db.Serie.Where(x => x.TrainingSessionId == id).Include(z => z.Shots).ToList();
            return series;
        }

        #endregion

        #region shotmethods
        public List<Shot> GetShotsBySerieId(int id)
        {
            List<Shot> shots = _db.Shot.Where(x => x.SerieId == id).ToList();
            return shots;
        }




        #endregion




      
        

        public int[] GetStatisticsValues(string ibuId, ValuesDto values)
        {
            var data = _db.TrainingSession.Where(x => x.IbuId == ibuId).Include(y => y.Results).ThenInclude(z => z.Shots);
            data.Select(a => a.Results.Select(b => b.Shots.Select(c => c.HeartRate))).ToList();
            return values.Data;
        }

        public int TrainingSessionIntensity()
        {
            return 70;
        }

        //public void SeedTrainingSessions( List <TrainingSession> trainingSessions)
        //{
        //    f
        //    _db.Add(trainingSessions);
        //    _db.SaveChanges();
        //}
    }
}
