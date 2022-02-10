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
      

        Task<List<TrainingSessionDto>>GetAimTrackerData();
        Task<List<TrainingSessionDto>> GetTrainingSessionsByDate(string athleteId, string startDate, string endDate);
       

    }
}
