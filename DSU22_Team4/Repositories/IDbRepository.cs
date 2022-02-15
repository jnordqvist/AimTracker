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
        //void UpdateAthlete(Athlete athlete);
        Task<Athlete> GetAthleteAsync();
        Athlete GetAthleteById(string id);
        void Seed(Athlete a);
        TrainingSession GetTrainingSession(string id);
        void AddSleepToAthlete(Athlete athlete, Sleep sleep);
        Athlete GetAthleteWithSleep(string id);
        //Athlete GetSleep(string id, DateTime date);
        void AddLatestTrainingSession(TrainingSession trainingSession);
        void SeedAthletes(List <AthleteDto> athlete);
        void SeedTrainingSessions( List <TrainingSessionDto> trainingSession);
        List<TrainingSession> GetTrainingSessions(string ibuId);
        int[] GetStatisticsValues(string ibuId, ValuesDto values);
        Serie GetSerie(int id);
    }
}
