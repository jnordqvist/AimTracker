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
        /// <summary>
        /// Gets the athlete from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A athlete by id</returns>
        public Athlete GetAthleteById(string id)
        {
            var athlete = _db.Athlete
                 .Where(x => x.Id == id).Include(i => i.Sleep);

            return athlete.FirstOrDefault();
        }

        /// <summary>
        /// Add athletes to the database
        /// </summary>
        /// <param name="athletedto"></param>
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
       
        /// <summary>
        /// Get one athletes all sessions including series and shots
        /// </summary>
        /// <param name="ibuId"></param>
        /// <returns> A list of trainingsessions </returns>
        public List<TrainingSession> GetTrainingSessions(string ibuId)
        {
            var trainingSessions = _db.TrainingSession.Where(x => x.IbuId == ibuId).OrderByDescending(y => y.Date)
                .Take(5).Include(x => x.Results).ThenInclude(y => y.Shots);
            return trainingSessions.ToList();
        }

        /// <summary>
        /// Gets the history by stance from one athlete
        /// </summary>
        /// <param name="ibuId"></param>
        /// <returns>a list of sessions by stance</returns>
        public List<TrainingSession> GetStandingShootingHistory(string ibuId)
        {
            var shootings = _db.TrainingSession.Where(x => x.IbuId == ibuId).Include(x => x.Results.Where(y => y.Stance == "Standing")).ToList();

            return shootings;
        }
        /// <summary>
        /// Adds trainingsession to database
        /// </summary>
        /// <param name="trainingSessionDto"></param>
        public void AddLatestTrainingSession(TrainingSessionDto trainingSessionDto)
        {
            var trainingsession = new TrainingSession(trainingSessionDto);
            _db.Add(trainingsession);
            _db.SaveChanges();
        }

        /// <summary>
        /// Add all trainingsessions to database
        /// </summary>
        /// <param name="trainingSessions"></param>
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
      
        /// <summary>
        ///  Get the list of series by trainingsession id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A list of series</returns>
        public List<Serie> GetResultsByTrainingSessionsId(TrainingSession session)
        {
            List<Serie> series = _db.Serie.Where(x => x.TrainingSessionId == session.Id).OrderBy(y => y.DateTime)
                .Include(z => z.Shots).ToList();
            return series;
        }

        #endregion

        #region shotmethods

        /// <summary>
        /// get at list of shots by serieId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a list of shots</returns>
        public List<Shot> GetShotsBySerieId(Serie serie)
        {
            List<Shot> shots = _db.Shot.Where(x => x.SerieId == serie.Id).OrderBy(y => y.ShotNr).ToList();
            return shots;
        }

        #endregion
    }
}
