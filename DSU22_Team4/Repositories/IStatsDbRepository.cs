using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public interface IStatsDbRepository
    {
        void UpdateAthlete(Athlete athlete);
        Task<Athlete> GetAthleteAsync();
        Athlete GetAthleteById(string id);
        void Seed(Athlete a);

   
        TrainingSession GetTrainingSession(string id);

        void AddSleepToAthlete(Athlete athlete, Sleep sleep);
        Athlete GetAthleteWithSleep(string id);
        Athlete GetSleep(string id, DateTime date);

    }
}
