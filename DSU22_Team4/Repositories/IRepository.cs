using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public interface IRepository
    {

   
        Task<List<AthleteDto>> GetAthletesAsync();
        void SeedAthletes(Athlete athlete);

        Task<List<TrainingSessionDto>>GetAimTrackerData();
        Task<List<TrainingSessionDto>> GetAimTrackerDataByDate(string athleteId, string startDate, string endDate);
       

    }
}
