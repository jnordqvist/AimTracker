using DSU22_Team4.Data;
using DSU22_Team4.Infrastructure;
using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class Repository : IRepository
    {
        #region privatefields
        private readonly IApiClient _apiClient;
        private readonly string baseEndPoint = "https://grupp8.dsvkurs.miun.se/api/Training/";
        private readonly string basePoint = "https://grupp8.dsvkurs.miun.se/api/history/Date/";
        private readonly string baseEndPointAthlete = "https://grupp8.dsvkurs.miun.se/api/athletes";
        private readonly string startDateEndpoint = "startDate=";
        private readonly string endDateEndpoint = "endDate=";

        private readonly AppDbContext _db;
        #endregion
        public Repository(IApiClient apiClient, AppDbContext db)
        {
            _apiClient = apiClient;
            _db = db;
        }

        #region apicalls
        /// <summary>
        ///  gets the latest trainingsession from api
        /// </summary>
        /// <param name="athleteId"></param>
        /// <returns> the latest trainingsession</returns>
        public async Task <TrainingSessionDto> GetLatestTrainingSession(string athleteId)
        {
            
            var trainingSession = await _apiClient.GetAsync<TrainingSessionDto>($"{baseEndPoint}{athleteId}");



            return trainingSession;
        }
        /// <summary>
        ///  Gets trainingsession by date
        /// </summary>
        /// <param name="athleteId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>trainingsessions by date</returns>
        public async Task<List<TrainingSessionDto>> GetTrainingSessionsByDate(string athleteId, string startDate, string endDate)
        {    
            
            var trainingSessions = await _apiClient.GetAsync <List<TrainingSessionDto>>($"{basePoint}" +
            $"{athleteId}?{startDateEndpoint}{startDate}&{endDateEndpoint}{endDate}");
           
            return trainingSessions;
        }
        /// <summary>
        /// Gets a list of athletes
        /// </summary>
        /// <returns>A list of athletes</returns>
        public async Task<List<AthleteDto>> GetAthletesAsync()
        {
            var athletes = await _apiClient.GetAsync<List<AthleteDto>>($"{baseEndPointAthlete}");
            return athletes;
        }

        #endregion
    }
}
