using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public interface IDbRepository
    {      
        Athlete GetAthleteById(string id);       
        void AddLatestTrainingSession(TrainingSessionDto trainingSession);
        void SeedAthletes(List <AthleteDto> athlete);
        void SeedTrainingSessions( List <TrainingSessionDto> trainingSession);
        List<TrainingSession> GetTrainingSessions(string ibuId);     
        List<Shot> GetShotsBySerieId(Serie serie);     
        List<TrainingSession> GetStandingShootingHistory(string ibuId);
        List<Serie> GetResultsByTrainingSessionsId(TrainingSession session);
    }
}
